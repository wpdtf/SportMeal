-- Процедура получения сотрудника по ID
CREATE PROCEDURE [dbo].[ПроцедураПолученияСотрудника]
    @ИдСотрудника INT
AS
BEGIN
    SELECT 
        с.ИдСотрудника AS Id,
        с.ИдПользователя AS UserId,
        с.Имя AS FirstName,
        с.Фамилия AS LastName,
        с.Должность AS Position,
        с.Телефон AS Phone,
        с.Почта AS Email,
        с.ДатаПриема AS HireDate,
        п.Логин AS Login,
        п.ХешПароля AS PasswordHash
    FROM Сотрудники с
    INNER JOIN Пользователи п ON с.ИдПользователя = п.ИдПользователя
    WHERE с.ИдСотрудника = @ИдСотрудника;
END;
GO

-- Процедура получения всех сотрудников
CREATE PROCEDURE [dbo].[ПроцедураПолученияВсехСотрудников]
AS
BEGIN
    SELECT 
        с.ИдСотрудника AS Id,
        с.ИдПользователя AS UserId,
        с.Имя AS FirstName,
        с.Фамилия AS LastName,
        с.Должность AS Position,
        с.Телефон AS Phone,
        с.Почта AS Email,
        с.ДатаПриема AS HireDate,
        п.Логин AS Login,
        п.ХешПароля AS PasswordHash
    FROM Сотрудники с
    INNER JOIN Пользователи п ON с.ИдПользователя = п.ИдПользователя;
END;
GO

-- Процедура регистрации сотрудника
CREATE PROCEDURE [dbo].[ПроцедураРегистрацииСотрудника]
    @Логин NVARCHAR(50),
    @ХешПароля NVARCHAR(255),
    @Имя NVARCHAR(50),
    @Фамилия NVARCHAR(50),
    @Телефон NVARCHAR(20),
    @Почта NVARCHAR(100),
    @Должность NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Проверка существования логина
        IF EXISTS (SELECT 1 FROM Пользователи WHERE Логин = @Логин)
        BEGIN
            THROW 50001, 'Пользователь с таким логином уже существует', 1;
        END

        -- Создание записи пользователя
        INSERT INTO Пользователи (Логин, ХешПароля, ТипПользователя, Активен)
        VALUES (@Логин, @ХешПароля, 'Сотрудник', 1);

        DECLARE @ИдПользователя INT = SCOPE_IDENTITY();

        -- Создание записи сотрудника
        INSERT INTO Сотрудники (ИдПользователя, Имя, Фамилия, Должность, Телефон, Почта, ДатаПриема)
        VALUES (@ИдПользователя, @Имя, @Фамилия, @Должность, @Телефон, @Почта, GETDATE());

        DECLARE @ИдСотрудника INT = SCOPE_IDENTITY();

        -- Возвращаем созданного сотрудника
        SELECT 
            с.ИдСотрудника AS Id,
            с.ИдПользователя AS UserId,
            с.Имя AS FirstName,
            с.Фамилия AS LastName,
            с.Должность AS Position,
            с.Телефон AS Phone,
            с.Почта AS Email,
            с.ДатаПриема AS HireDate,
            п.Логин AS Login,
            п.ХешПароля AS PasswordHash
        FROM Сотрудники с
        INNER JOIN Пользователи п ON с.ИдПользователя = п.ИдПользователя
        WHERE с.ИдСотрудника = @ИдСотрудника;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- Процедура обновления данных сотрудника
CREATE PROCEDURE [dbo].[ПроцедураОбновленияСотрудника]
    @ИдСотрудника INT,
    @Имя NVARCHAR(50),
    @Фамилия NVARCHAR(50),
    @Телефон NVARCHAR(20),
    @Почта NVARCHAR(100),
    @Должность NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @ИдПользователя INT;
        SELECT @ИдПользователя = ИдПользователя FROM Сотрудники WHERE ИдСотрудника = @ИдСотрудника;

        UPDATE Сотрудники
        SET 
            Имя = @Имя,
            Фамилия = @Фамилия,
            Должность = @Должность,
            Телефон = @Телефон,
            Почта = @Почта
        WHERE ИдСотрудника = @ИдСотрудника;

        UPDATE Пользователи
        SET Логин = @Почта
        WHERE ИдПользователя = @ИдПользователя;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- Процедура удаления сотрудника
CREATE PROCEDURE [dbo].[ПроцедураУдаленияСотрудника]
    @ИдСотрудника INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @ИдПользователя INT;
        SELECT @ИдПользователя = ИдПользователя FROM Сотрудники WHERE ИдСотрудника = @ИдСотрудника;

        DELETE FROM Сотрудники WHERE ИдСотрудника = @ИдСотрудника;
        DELETE FROM Пользователи WHERE ИдПользователя = @ИдПользователя;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO 