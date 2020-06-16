Use CoquoDbRev4
go

insert into Ingredients(IngredientName , IngredientDescription) values
	('Ribeye Steak','longissimus dorsi, complexus, and spinalis muscles'),
	('Russet Potato','Best for baking, mashing, and frying'),
	('Ground Beef','Ground chuck, 20% Fat'),
	('Hamburger Buns', 'a sliced bread roll'),
	('Cheddar Cheese','Originated in the English village of Cheddar in Somerset'),
	('Lingcod','great for frying & baking'),
	('Flour','a powder made by grinding raw wheat grain, used for baking'),
	('Bacon','salt cured pork belly')


insert into Dishes(DishName, DishDescription) values
	('Ribeye Steak','Grilling is great, but here the oven is KING...'),
	('Stuffed Baked Potatoes','Russet potatoes, butter, sour cream, grated cheddar, & green onions'),
	('Beer Battered Fish','English style beer battered deep fat fried fish, great with french fries'),
	('French Fries','Deep fried, batonnet cut, potatoes ')

insert into Cooks(DishID,IngredientID) values
	(1,1),
	(2,2),
	(2,5),
	(2,8)

select *
from Ingredients

select *
from Dishes

select *
from Cooks
