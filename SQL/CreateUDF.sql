USE OnlineOrdersDB;

GO

CREATE FUNCTION dbo.udf_GetOrderSum (@ProductItems varchar(255))
    RETURNS DECIMAL(18, 2)
BEGIN

	RETURN (SELECT SUM(Price)
			FROM ProductsItem 
			JOIN STRING_SPLIT(@ProductItems,',')
				ON value = ID); 
END;