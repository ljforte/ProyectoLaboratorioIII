Use Compumundo_hipermegared
GO

CREATE VIEW ListarArticulos AS
                            SELECT 
            A.Id,
            A.Codigo, 
            A.Nombre, 
            A.Descripcion, 
            M.nombre AS Marca, 
            C.nombre AS Categoria, 
            A.Precio,
            M.IdMarca as IdMarca,
            C.IdCategoria as IdCategoria,
            I.ImagenUrl as Imagen,
			A.Estado as Estado,
            P.Nombre AS ProveedorNombre,
			P.id_proveedor AS id_proveedor,
			s.stock as Stock
        FROM ARTICULOS AS A 
        LEFT JOIN Marcas AS M ON A.IdMarca = M.IdMarca 
        LEFT JOIN Categorias AS C ON A.IdCategoria = C.IdCategoria
        LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id
        LEFT JOIN Proveedor AS P ON A.id_proveedor = P.id_proveedor
		LEFT JOIN Stock as S ON A.id = S.id
Go

CREATE PROCEDURE spFiltrarArticulos
    @Campo NVARCHAR(50),
    @Criterio NVARCHAR(50),
    @Filtro NVARCHAR(255)
AS
BEGIN
    DECLARE @Consulta NVARCHAR(MAX);

    SET @Consulta = '
        ListarArticulos';

    IF @Campo = 'Codigo'
        SET @Consulta += CASE 
            WHEN @Criterio = 'Comienza con' THEN 'A.Codigo LIKE ''' + @Filtro + '%'''
            WHEN @Criterio = 'Termina con' THEN 'A.Codigo LIKE ''%' + @Filtro + ''''
            ELSE 'A.Codigo LIKE ''%' + @Filtro + '%'''
        END;
    ELSE IF @Campo = 'Nombre'
        SET @Consulta += CASE 
            WHEN @Criterio = 'Comienza con' THEN 'A.Nombre LIKE ''' + @Filtro + '%'''
            WHEN @Criterio = 'Termina con' THEN 'A.Nombre LIKE ''%' + @Filtro + ''''
            ELSE 'A.Nombre LIKE ''%' + @Filtro + '%'''
        END;
    ELSE IF @Campo = 'Marca'
        SET @Consulta += CASE 
            WHEN @Criterio = 'Comienza con' THEN 'M.Descripcion LIKE ''' + @Filtro + '%'''
            WHEN @Criterio = 'Termina con' THEN 'M.Descripcion LIKE ''%' + @Filtro + ''''
            ELSE 'M.Descripcion LIKE ''%' + @Filtro + '%'''
        END;
    ELSE IF @Campo = 'Categoria'
        SET @Consulta += CASE 
            WHEN @Criterio = 'Comienza con' THEN 'C.Descripcion LIKE ''' + @Filtro + '%'''
            WHEN @Criterio = 'Termina con' THEN 'C.Descripcion LIKE ''%' + @Filtro + ''''
            ELSE 'C.Descripcion LIKE ''%' + @Filtro + '%'''
        END;
    ELSE IF @Campo = 'Precio'
        SET @Consulta += CASE 
            WHEN @Criterio = 'Mayor a' THEN 'A.Precio > ' + @Filtro
            WHEN @Criterio = 'Menor a' THEN 'A.Precio < ' + @Filtro
            ELSE 'A.Precio = ' + @Filtro
        END;

    EXEC sp_executesql @Consulta;
END;
GO



CREATE PROCEDURE sp_BajaLogicaProducto
    @Id INT
AS
BEGIN
    UPDATE Articulos
    SET estado = 0
    WHERE Id = @Id;
END
GO


CREATE TRIGGER trg_EliminarArticulo
ON ARTICULOS
FOR DELETE
AS
BEGIN
    DECLARE @Stock INT;
    DECLARE @Id INT;

    SELECT @Id = id FROM DELETED;

    SELECT @Stock = stock FROM stock WHERE id = @Id;

    IF (@Stock > 0)
    BEGIN

        RAISERROR('No se puede eliminar el producto porque tiene stock disponible.', 16, 1);
        ROLLBACK;  
    END
    ELSE IF (@Stock = 0)
    BEGIN
        -- Si el stock es 0, eliminamos el registro en la tabla stock
        DELETE FROM stock WHERE id = @Id;
    END
END;
GO

CREATE PROCEDURE sp_ProveedorConMasArticulos
AS
BEGIN
    -- Obtener la cantidad máxima de artículos para un proveedor
    DECLARE @MaxCantidad INT;
    SELECT @MaxCantidad = MAX(CantidadArticulos)
    FROM (
        SELECT COUNT(A.Id) AS CantidadArticulos
        FROM proveedor AS P
        JOIN Articulos AS A ON P.id_proveedor = A.id_proveedor
        GROUP BY P.id_proveedor
    ) AS Subconsulta;

    -- Seleccionar todos los proveedores con la cantidad máxima de artículos
    SELECT 
        P.id_proveedor,
        P.nombre,
        COUNT(A.Id) AS CantidadArticulos
    FROM 
        proveedor AS P
    JOIN 
        Articulos AS A ON P.id_proveedor = A.id_proveedor
    GROUP BY 
        P.id_proveedor, P.nombre
    HAVING 
        COUNT(A.Id) = @MaxCantidad
    ORDER BY 
        CantidadArticulos DESC;
END;
GO
