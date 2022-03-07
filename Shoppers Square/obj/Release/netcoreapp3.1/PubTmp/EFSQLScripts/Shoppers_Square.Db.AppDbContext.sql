IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    IF SCHEMA_ID(N'Identity') IS NULL EXEC(N'CREATE SCHEMA [Identity];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[Category] (
        [Id] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(max) NOT NULL,
        [Slug] nvarchar(max) NOT NULL,
        [isDelete] int NOT NULL,
        [isActive] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[Register] (
        [UID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Register] PRIMARY KEY ([UID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[Role] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[User] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(max) NULL,
        [NormalizedUserName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [NormalizedEmail] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[UserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[UserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_UserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[UserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_UserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[SubCategoryViewModel] (
        [Id] int NOT NULL IDENTITY,
        [SubCategoryName] nvarchar(max) NOT NULL,
        [SubCategorySlug] nvarchar(max) NOT NULL,
        [CategoryId] int NOT NULL,
        [isDelete] int NOT NULL,
        [isActive] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_SubCategoryViewModel] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubCategoryViewModel_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Identity].[Category] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[RoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RoleClaims_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE TABLE [Identity].[UserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [EmailIndex] ON [Identity].[AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [Identity].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [Identity].[Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [IX_RoleClaims_RoleId] ON [Identity].[RoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [IX_SubCategoryViewModel_CategoryId] ON [Identity].[SubCategoryViewModel] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [IX_UserClaims_UserId] ON [Identity].[UserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [IX_UserLogins_UserId] ON [Identity].[UserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    CREATE INDEX [IX_UserRoles_RoleId] ON [Identity].[UserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116124416_category')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211116124416_category', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116130205_subcatgory')
BEGIN
    DROP TABLE [Identity].[SubCategoryViewModel];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116130205_subcatgory')
BEGIN
    CREATE TABLE [Identity].[Subcategory] (
        [Id] int NOT NULL IDENTITY,
        [SubCategoryName] nvarchar(max) NOT NULL,
        [Slug] nvarchar(max) NOT NULL,
        [CategoryId] int NOT NULL,
        [isDelete] int NOT NULL,
        [isActive] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_Subcategory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Subcategory_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Identity].[Category] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116130205_subcatgory')
BEGIN
    CREATE INDEX [IX_Subcategory_CategoryId] ON [Identity].[Subcategory] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116130205_subcatgory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211116130205_subcatgory', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116170940_product')
BEGIN
    CREATE TABLE [Identity].[Product] (
        [Id] int NOT NULL IDENTITY,
        [SubCategoryId] int NOT NULL,
        [ProductName] nvarchar(max) NOT NULL,
        [Slug] nvarchar(max) NOT NULL,
        [ProductBrand] nvarchar(max) NOT NULL,
        [OrginalPrice] real NOT NULL,
        [DiscountPrice] real NOT NULL,
        [isDelete] int NOT NULL,
        [isActive] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Product_Subcategory_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [Identity].[Subcategory] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116170940_product')
BEGIN
    CREATE INDEX [IX_Product_SubCategoryId] ON [Identity].[Product] ([SubCategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211116170940_product')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211116170940_product', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117161615_productImages')
BEGIN
    CREATE TABLE [Identity].[Images] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [ImageName] nvarchar(max) NULL,
        [ImagesUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Images] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Images_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Identity].[Product] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117161615_productImages')
BEGIN
    CREATE INDEX [IX_Images_ProductId] ON [Identity].[Images] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117161615_productImages')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211117161615_productImages', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117162225_productImages2')
BEGIN
    ALTER TABLE [Identity].[Images] ADD [Dated] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117162225_productImages2')
BEGIN
    ALTER TABLE [Identity].[Images] ADD [Slug] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117162225_productImages2')
BEGIN
    ALTER TABLE [Identity].[Images] ADD [isActive] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117162225_productImages2')
BEGIN
    ALTER TABLE [Identity].[Images] ADD [isDelete] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211117162225_productImages2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211117162225_productImages2', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119131855_product2')
BEGIN
    ALTER TABLE [Identity].[Product] ADD [UrlImage] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119131855_product2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Identity].[Category]') AND [c].[name] = N'CategoryName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Identity].[Category] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Identity].[Category] ALTER COLUMN [CategoryName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119131855_product2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211119131855_product2', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171133_order')
BEGIN
    CREATE TABLE [Identity].[Order] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NULL,
        [UserId] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [Pincode] nvarchar(max) NULL,
        [PaymentType] nvarchar(max) NULL,
        [OrderStatus] nvarchar(max) NULL,
        [isDelete] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171133_order')
BEGIN
    CREATE TABLE [Identity].[OrderItems] (
        [Id] int NOT NULL IDENTITY,
        [Amount] int NOT NULL,
        [Price] float NOT NULL,
        [ProductId] int NOT NULL,
        [OrderId] int NOT NULL,
        [isDelete] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_Order_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Identity].[Order] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Identity].[Product] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171133_order')
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [Identity].[OrderItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171133_order')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211119171133_order', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171744_shoppingcart')
BEGIN
    CREATE TABLE [Identity].[ShoppingCartItems] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NULL,
        [Amount] int NOT NULL,
        [ShoppingCartId] nvarchar(max) NULL,
        CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCartItems_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Identity].[Product] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171744_shoppingcart')
BEGIN
    CREATE INDEX [IX_ShoppingCartItems_ProductId] ON [Identity].[ShoppingCartItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211119171744_shoppingcart')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211119171744_shoppingcart', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211120131718_update_order_items_table')
BEGIN
    ALTER TABLE [Identity].[OrderItems] DROP CONSTRAINT [FK_OrderItems_Order_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211120131718_update_order_items_table')
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [Identity].[OrderItems] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211120131718_update_order_items_table')
BEGIN
    ALTER TABLE [Identity].[OrderItems] ADD CONSTRAINT [FK_OrderItems_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Identity].[Order] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211120131718_update_order_items_table')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211120131718_update_order_items_table', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201115636_OrderEnquiry')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Identity].[Category]') AND [c].[name] = N'CategoryName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Identity].[Category] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Identity].[Category] ALTER COLUMN [CategoryName] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201115636_OrderEnquiry')
BEGIN
    CREATE TABLE [Identity].[OrderEnquiry] (
        [Id] int NOT NULL IDENTITY,
        [OrderId] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [isDelete] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_OrderEnquiry] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderEnquiry_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Identity].[Order] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201115636_OrderEnquiry')
BEGIN
    CREATE INDEX [IX_OrderEnquiry_OrderId] ON [Identity].[OrderEnquiry] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201115636_OrderEnquiry')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201115636_OrderEnquiry', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201130146_enquiry2')
BEGIN
    ALTER TABLE [Identity].[OrderEnquiry] DROP CONSTRAINT [PK_OrderEnquiry];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201130146_enquiry2')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Identity].[OrderEnquiry]') AND [c].[name] = N'Id');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Identity].[OrderEnquiry] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Identity].[OrderEnquiry] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201130146_enquiry2')
BEGIN
    ALTER TABLE [Identity].[OrderEnquiry] ADD [EnquiryId] int NOT NULL IDENTITY;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201130146_enquiry2')
BEGIN
    ALTER TABLE [Identity].[OrderEnquiry] ADD CONSTRAINT [PK_OrderEnquiry] PRIMARY KEY ([EnquiryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201130146_enquiry2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201130146_enquiry2', N'3.1.21');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201163257_productdescription')
BEGIN
    CREATE TABLE [Identity].[ProductDescription] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [Slug] nvarchar(max) NOT NULL,
        [LongDescription] nvarchar(max) NOT NULL,
        [isDelete] int NOT NULL,
        [isActive] int NOT NULL,
        [Dated] datetime2 NOT NULL,
        CONSTRAINT [PK_ProductDescription] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductDescription_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Identity].[Product] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201163257_productdescription')
BEGIN
    CREATE INDEX [IX_ProductDescription_ProductId] ON [Identity].[ProductDescription] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211201163257_productdescription')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211201163257_productdescription', N'3.1.21');
END;

GO

