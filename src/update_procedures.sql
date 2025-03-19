-- Обновление процедуры создания заказа
CREATE OR ALTER PROCEDURE [dbo].[ПроцедураСозданияЗаказа]
    @ИдКлиента INT,
    @ИдСотрудника INT,
    @ДатаЗаказа DATETIME,
    @СуммаЗаказа DECIMAL(10,2),
    @Статус INT
AS
BEGIN
    DECLARE @СтатусТекст NVARCHAR(20);
    
    SET @СтатусТекст = CASE @Статус
        WHEN 0 THEN 'Новый'
        WHEN 1 THEN 'ВОбработке'
        WHEN 2 THEN 'Завершен'
        WHEN 3 THEN 'Отменен'
    END;
    
    INSERT INTO Заказы (ИдКлиента, ИдСотрудника, ДатаЗаказа, СуммаЗаказа, Статус)
    VALUES (@ИдКлиента, @ИдСотрудника, @ДатаЗаказа, @СуммаЗаказа, @СтатусТекст);
    
    SELECT 
        з.ИдЗаказа AS Id,
        з.ИдКлиента AS ClientId,
        з.ИдСотрудника AS EmployeeId,
        з.ДатаЗаказа AS OrderDate,
        з.СуммаЗаказа AS TotalAmount,
        CASE з.Статус
            WHEN 'Новый' THEN 0
            WHEN 'ВОбработке' THEN 1
            WHEN 'Завершен' THEN 2
            WHEN 'Отменен' THEN 3
        END AS Status
    FROM Заказы з
    WHERE з.ИдЗаказа = SCOPE_IDENTITY();
END;
GO

-- Обновление процедуры добавления позиции заказа
CREATE OR ALTER PROCEDURE [dbo].[ПроцедураДобавленияПозицииЗаказа]
    @ИдЗаказа INT,
    @ИдТовара INT,
    @Количество INT,
    @ЦенаЗаЕдиницу DECIMAL(10,2)
AS
BEGIN
    INSERT INTO ПозицииЗаказа (ИдЗаказа, ИдТовара, Количество, ЦенаЗаЕдиницу)
    VALUES (@ИдЗаказа, @ИдТовара, @Количество, @ЦенаЗаЕдиницу);
    
    SELECT 
        пз.ИдПозиции AS Id,
        пз.ИдЗаказа AS OrderId,
        пз.ИдТовара AS ProductId,
        пз.Количество AS Quantity,
        пз.ЦенаЗаЕдиницу AS UnitPrice
    FROM ПозицииЗаказа пз
    WHERE пз.ИдПозиции = SCOPE_IDENTITY();
END;
GO

-- Обновление процедуры создания товара
CREATE OR ALTER PROCEDURE [dbo].[ПроцедураСозданияТовара]
    @НазваниеТовара NVARCHAR(200),
    @Описание NVARCHAR(MAX),
    @Цена DECIMAL(10,2),
    @КоличествоНаСкладе INT,
    @ИдКатегории INT
AS
BEGIN
    INSERT INTO Товары (НазваниеТовара, Описание, Цена, КоличествоНаСкладе, ИдКатегории)
    VALUES (@НазваниеТовара, @Описание, @Цена, @КоличествоНаСкладе, @ИдКатегории);
    
    SELECT 
        т.ИдТовара AS Id,
        т.НазваниеТовара AS Name,
        т.Описание AS Description,
        т.Цена AS Price,
        т.КоличествоНаСкладе AS StockQuantity,
        т.ИдКатегории AS CategoryId
    FROM Товары т
    WHERE т.ИдТовара = SCOPE_IDENTITY();
END;
GO

-- Обновление процедуры отчета по продажам за период
CREATE OR ALTER PROCEDURE [dbo].[ПроцедураОтчетаПоПродажамЗаПериод]
    @ДатаНачала DATETIME,
    @ДатаКонца DATETIME
AS
BEGIN
    SELECT 
        CAST(з.ДатаЗаказа AS DATE) AS Date,
        COUNT(DISTINCT з.ИдЗаказа) AS OrderCount,
        SUM(з.СуммаЗаказа) AS TotalSales,
        CAST(AVG(з.СуммаЗаказа) AS DECIMAL(10,2)) AS AverageOrderValue
    FROM Заказы з
    WHERE з.ДатаЗаказа BETWEEN @ДатаНачала AND @ДатаКонца
    AND з.Статус = 'Завершен'
    GROUP BY CAST(з.ДатаЗаказа AS DATE)
    ORDER BY Date;
END;
GO 