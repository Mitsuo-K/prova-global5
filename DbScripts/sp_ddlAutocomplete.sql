CREATE PROCEDURE [dbo].sp_ddlAutocomplete
@Action int

as

if @Action = 1 -- Get Supplier
begin
	select 
		0 as [Id], 
		'select' as [Name], 
		1 as [Status]
	UNION

	select 
		[Id], 
		[Name], 
		[Status]
	from Supplier
	order by [Status] desc
end

if @Action = 2 -- Get Materials
begin
	select 
		0 as [Id], 
		'select' as [Name], 
		1 as [Status]
	UNION
	select 
		[Id], 
		[Name], 
		[Status]
	from Materials
	order by [Status] desc
end