CREATE PROCEDURE sp_Supplier
@Action int ,
@Id Bigint ,
@Name Nvarchar(255),
@Email Nvarchar(255),
@DDD Nvarchar(3),
@Phone Nvarchar(11),
@Status int

as

if @Action = 1 --Create 
begin
	Insert into Supplier(
	[Name],
	[Email],
	[DDD],
	[PhoneNumber],
	[CreatedDate],
	[Status]
	)
	output inserted.Id
	Values(
	@Name,
	@Email,
	@DDD,
	@Phone,
	GETDATE(),
	1)
end
if @Action = 2 --Update 
begin
	Update Supplier
	set [Name] = ISNULL(@Name,[Name]),
	[Email] = ISNULL(@Email,[Email]),
	[DDD]= ISNULL(@DDD,[DDD]),
	[PhoneNumber] = ISNULL(@Phone,[PhoneNumber]),
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
		[Email],
		[DDD],
		[PhoneNumber],
		[CreatedDate],
		[LastUpdatedDate],
		[CanceledDate],
		[Status]
	from Supplier
	Where(1=1)
	and ((@Id is null) or ([Id] = @Id))
	and ((@Name is null) or ([Name] like '%' + @Name + '%'))
	and ((@Email is null) or ([Email] like '%' + @Email + '%'))
	and ((@DDD is null) or ([DDD] = @DDD))
	and ((@Phone is null) or ([PhoneNumber] = @Phone))
	and ((@Status is null) or ([Status] = @Status))
	order by [Status] desc
end