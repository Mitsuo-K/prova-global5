CREATE PROCEDURE [dbo].sp_Stock
@Action int ,
@Id Bigint ,
@MaterialId Bigint,
@SupplierId Bigint,
@Qtty Int,
@Status int

as

if @Action = 1 --Create 
begin
	DECLARE @outputTable Table(id Int)

	Insert into [Stock](
	[MaterialId],
	[SupplierId],
	[Qtty],
	[CreatedDate],
	[Status]
	)
	output inserted.Id into @outputTable
	Values(
	@MaterialId,
	@SupplierId,
	@Qtty,
	GETDATE(),
	1)

	Insert into [StockHist](
		[StockId],
		[OldQtty],
		[NewQtty],
		[CreatedDate]
	)
	output inserted.StockId as Id
	Values(
		(Select top 1 id from @outputTable),
		0,
		@Qtty,
		GetDate()
	)

end
if @Action = 2 --Update 
begin
	DECLARE @OldQtty int = (Select [Qtty] from [Stock] where [Id] = @Id)

	Update [Stock]
	set [Qtty] = ISNULL(@Qtty,[Qtty]),
		[LastUpdatedDate] = GETDATE(),
		[Status] = ISNULL(@Status,[Status])
	where(1=1)
	and [Id] = @Id

	Insert into [StockHist](
		[StockId],
		[OldQtty],
		[NewQtty],
		[CreatedDate]
	)
	output inserted.StockId as Id
	Values(
		@Id,
		@OldQtty ,
		@Qtty,
		GetDate()
	)
end
if @Action = 3 --Select 
begin
	Select 
		[Stock].[Id],
		[MaterialId],
		[Materials].[Name] as Materials,
		[SupplierId],
		[Supplier].[Name] as Supplier,
		[Qtty],
		[Stock].[CreatedDate],
		[Stock].[LastUpdatedDate],
		[Stock].[Status]
	from [Stock]
	Inner join Supplier on Supplier.Id = Stock.SupplierId
	Inner join Materials on Materials.Id = Stock.MaterialId
	Where(1=1)
	and ((@Id is null) or ([Stock].[Id] = @Id))
	and ((@MaterialId is null) or ([MaterialId] = @MaterialId))
	and ((@SupplierId is null) or ([SupplierId] = @SupplierId))
	and ((@Status is null) or ([Stock].[Status] = @Status))
	order by [Stock].[Status] desc
end

