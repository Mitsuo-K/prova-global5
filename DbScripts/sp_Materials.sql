CREATE PROCEDURE [dbo].sp_Materials
@Action int ,
@Id Bigint ,
@Name Nvarchar(255),
@Code Nvarchar(255),
@DueDate DateTime,
@Status int

as

if @Action = 1 --Create 
begin
	Insert into Materials(
	[Name],
	[Code],
	[DueDate],
	[CreatedDate],
	[Status]
	)
	output inserted.Id
	Values(
	@Name,
	@Code,
	@DueDate,
	GETDATE(),
	1)
end
if @Action = 2 --Update 
begin
	Update Materials
	set [Name] = ISNULL(@Name,[Name]),
	[Code] = ISNULL(@Code,[Code]),
	[DueDate]= ISNULL(@DueDate,[DueDate]),
	[LastUpdatedDate] = GETDATE(),
	[CanceledDate] = Case 
							When @Status is not null and @Status = 0 then GETDATE() 
							when @Status is null then [CanceledDate] 
							else null 
					 end,
	[Status] = ISNULL(@Status,[Status])
	output inserted.Id
	where(1=1)
	and [Id] = @Id
end
if @Action = 3 --Select 
begin
	Select 
		[Id],
		[Name],
		[Code],
		[DueDate],
		[CreatedDate],
		[LastUpdatedDate],
		[CanceledDate],
		[Status]
	from Materials
	Where(1=1)
	and ((@Id is null) or ([Id] = @Id))
	and ((@Name is null) or ([Name] like '%' + @Name + '%'))
	and ((@Code is null) or ([Code] = @Code))
	and ((@DueDate is null) or ([DueDate] = @DueDate))
	and ((@Status is null) or ([Status] = @Status))
end
