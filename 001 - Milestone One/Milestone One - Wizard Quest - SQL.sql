drop database if exists WizardQuest;
create database WizardQuest;
use WizardQuest;

drop procedure if exists ddlWizardQuestDB;
drop procedure if exists dmlWizardQuestDB;


delimiter //
create procedure ddlWizardQuestDB()
begin

create table tblUser(
	UserID int not null auto_increment primary key,
    UserName varchar(30) not null unique,
    UserPassword varchar(20) not null,
	Email varchar(50) not null,
    LoginAttempts int not null,
    UserLocked bool not null,
    UserOnline bool not null,
    Administrator bool not null,
    TotalScore int not null 
    );
    
create table tblQuest(
	QuestID int not null auto_increment primary key,
    QuestName varchar(50) not null,
    MaxUsers int not null,
    ActivePlayer int,
    QuestStatus bool
    );
    
create table tblQuestMap(
	MapID int not null auto_increment primary key,
    QuestID int not null,
    xMax int not null,
    yMax int not null,
    foreign key (QuestID) references tblQuest(QuestID)
    );
    
create table tblQuestMapTile(
	TileID int not null auto_increment primary key,
    MapID int not null,
    xPosition int not null,
    yPosition int not null,
    TileActive bool,
    foreign key (MapID) references tblQuestMap(MapID)
    );
    
create table tblAsset(
	AssetID int not null auto_increment primary key,
    AssetName varchar(30) not null,
    AssetDescription varchar(50) not null,
    AssetValue int not null
    );
    
create table tblQuestTileAsset(
	TileAssetID int not null auto_increment primary key,
	TileID int not null,
    AssetID int not null,
    foreign key (TileID) references tblQuestMapTile(TileID),
    foreign key (AssetID) references tblAsset(AssetID)
    );
    
create table tblChat(
	ChatID int not null auto_increment primary key,
    UserID int not null,
    Message varchar(255),
    foreign key (UserID) references tblUser(UserID) on delete cascade
    );
    
create table tblQuestPlay(
	QuestPlayID int not null auto_increment primary key,
    UserID int not null,
    TileID int,
    ChatID int,
    QuestID int,
    PlayerNumber int,
    foreign key (UserID) references tblUser(UserID),
    foreign key (TileID) references tblQuestMapTile(TileID),
    foreign key (ChatID) references tblChat(ChatID),
    foreign key (QuestID) references tblQuest(QuestID)
    );
    
create table tblQuestPlayInventory(
	InventoryID int not null auto_increment primary key,
    QuestPlayID int not null,
    AssetID int,
    Quantity int,
    foreign key (QuestPlayID) references tblQuestPlay(QuestPlayID),
    foreign key (AssetID) references tblAsset(AssetID)
    );
    
create table tblQuestScore(
	ScoreID int not null auto_increment primary key,
    CurrentQuestScore int,
    QuestPlayID int not null,
    QuestID int not null,
    foreign key (QuestPlayID) references tblQuestPlay(QuestPlayID),
    foreign key (QuestID) references tblQuest(QuestID)
    );
    
end //
delimiter ;



delimiter //
create procedure dmlWizardQuestDB()
begin

-- insert statements

insert into tblUser (UserName, UserPassword, Email, LoginAttempts, UserLocked, UserOnline, Administrator, TotalScore)
	values 
    ('Daniel', '1234', 'daniel@emailaddress.com', '0', '0', '0', '1', '0'),
    ('Bob', '1234', 'bob@emailaddress.com', '0', '0', '0', '1', '0'),
    ('Sally', '1234', 'sally@emailaddress.com', '5', '1', '0', '0', '1024'),
    ('Alexis', '1234', 'alexis@emailaddress.com', '0', '0', '0', '0', '25600');
    
insert into tblAsset (AssetName, AssetDescription, AssetValue)
	values
    ('Gold', 'Wizard Gold', '100'),
    ('Wand', 'The Wizard Wand', '500'),
    ('Gem', 'The Spell Gem', '500'),
    ('Cloak', 'The Cloak of Invisibility', '500'),
    ('Destoryed', 'Spell Book Destroyed', '-500'),
    ('Area', 'Magic Dead Area', '-500');
    
insert into tblQuest (QuestName, MaxUsers, ActivePlayer, QuestStatus)
	values
    ('Bobs Quest', '4', '1', '1'),
    ('Sallys Quest', '4', '1', '1');

insert into tblQuestMap (QuestID, xMax, yMax)
	values
    ('1', '19', '19'),
    ('2', '19', '19');
    
insert into tblQuestMapTile (MapID, xPosition, yPosition, TileActive)
	values
    ('1', '0', '0', true), ('1', '0', '1', true), ('1', '0', '2', true), ('1', '0', '3', true), ('1', '0', '4', true), ('1', '0', '5', true), ('1', '0', '6', true), ('1', '0', '7', true), ('1', '0', '8', true), ('1', '0', '9', true), ('1', '0', '10', true), ('1', '0', '11', true), ('1', '0', '12', true), ('1', '0', '13', true), ('1', '0', '14', true), ('1', '0', '15', true), ('1', '0', '16', true), ('1', '0', '17', true), ('1', '0', '18', true), ('1', '0', '19', true),
    ('1', '1', '0', true), ('1', '1', '1', true), ('1', '1', '2', true), ('1', '1', '3', true), ('1', '1', '4', true), ('1', '1', '5', true), ('1', '1', '6', true), ('1', '1', '7', true), ('1', '1', '8', true), ('1', '1', '9', true), ('1', '1', '10', true), ('1', '1', '11', true), ('1', '1', '12', true), ('1', '1', '13', true), ('1', '1', '14', true), ('1', '1', '15', true), ('1', '1', '16', true), ('1', '1', '17', true), ('1', '1', '18', true), ('1', '1', '19', true),
    ('1', '2', '0', true), ('1', '2', '1', true), ('1', '2', '2', true), ('1', '2', '3', true), ('1', '2', '4', true), ('1', '2', '5', true), ('1', '2', '6', true), ('1', '2', '7', true), ('1', '2', '8', true), ('1', '2', '9', true), ('1', '2', '10', true), ('1', '2', '11', true), ('1', '2', '12', true), ('1', '2', '13', true), ('1', '1', '14', true), ('1', '2', '15', true), ('1', '2', '16', true), ('1', '2', '17', true), ('1', '2', '18', true), ('1', '2', '19', true); 
    
insert into tblQuestTileAsset (TileID, AssetID)
	values
    ('1', '1'), ('3', '1'), ('4', '1'), ('11', '1'), ('13', '1'), ('15', '1'), ('16', '2'), ('19', '3'), ('21', '4'), ('24', '5'), ('25', '6'), ('31', '1');
    
insert into tblChat (UserID, Message)
	values
    ('2', 'I will be victorious!'),
    ('3', 'I am the wizard queen');
    
insert into tblQuestPlay (UserID, TileID, ChatID, QuestID, PlayerNumber)
	values
    ('2', '1', null, '1', '1'),
    ('3', '1', null, '2', '1');
    
insert into tblQuestPlayInventory (QuestPlayID, AssetID, Quantity)
	values
    ('1', null, 0),
    ('2', null, 0);
    
insert into tblQuestScore (QuestID, QuestPlayID, CurrentQuestScore)
	values
    ('1', '1', '0'),
    ('2', '2', '0');


-- select statements

select -- lists accounts that are locked
	UserID, UserName
	from tblUser
    where UserLocked = true;
    
select -- shows game assets that lose players points
	AssetName, AssetValue
    from tblAsset
    where AssetValue <0;
    
select -- show games currently in progress
	QuestID, QuestName
    from tblQuest
    where QuestStatus = true;
    
select count(*) as NumberOfQuestMaps  -- shows number of maps in database
    from tblQuestMap;
    
select -- shows game tiles currently in play
	TileID, xPosition as rowNumber, yPosition as columnNumber
	from tblQuestMapTile
    where TileActive = true;

select count(*) as NumberOfTilesWithGold -- counts tile with gold on them
	from tblQuestTileAsset
    where AssetID = 1;
    
select distinct-- shows userid of players chatting
	UserID
    from tblChat;
    
select -- shows games where players have not left the home tile
	QuestPlayID, UserID, QuestID
    from tblQuestPlay
    where TileID = 1;
    
select sum(distinct Quantity) as TotalAssetsCurrentlyAttained -- shows total assets already collected in a game
	from tblQuestPlayInventory
    where QuestPlayID = 1;

select -- shows top ten current game scores
	QuestID, QuestPlayID, CurrentQuestScore
    from tblQuestScore
    Order by CurrentQuestScore
    Limit 10;
    

-- update statements

update tblUser -- Administrator unlocks user
	set tblUser.UserLocked = false, tblUser.LoginAttempts = 0
	where tblUser.UserID = 3;
    
update tblAsset -- Updates points value of gold
	set tblAsset.AssetValue = 200
    where tblAsset.AssetID = 1;
    
update tblQuest -- Changes game status to offline
	set tblQuest.QuestStatus = false
    where QuestID = 2;

update tblQuestMap -- Increase map max size
	set tblQuestMap.xMax = 29, tblQuestMap.yMax = 29
    where tblQuestMap.QuestID = 2;
    
update tblQuestMapTile -- tile no longer active
	set tblQuestMapTile.TileActive = false
    where tblQuestMapTile.TileID = 2;

update tblQuestTileAsset -- changes type of asset on tile
	set tblQuestTileAsset.AssetID = 3
    where tblQuestTileAsset.TileID = 11;
    
update tblChat -- alter chat message
	set tblChat.Message = "I love wizardquest!"
	where tblChat.ChatID = 1;

update tblQuestPlay -- player moves tile
	set tblQuestPlay.TileID = 2
    where tblQuestPlay.QuestPlayID = 1;
    
update tblQuestPlayInventory -- add item to inventory
	set tblQuestPlayInventory.AssetID = 1, tblQuestPlayInventory.Quantity = Quantity+1
    where tblQuestPlayInventory.InventoryID = 1;
    
update tblQuestScore, tblQuestPlayInventory, tblAsset -- add item from inventory to game score
	set tblQuestScore.CurrentQuestScore = CurrentQuestScore+(tblQuestPlayInventory.Quantity*tblAsset.AssetValue)
    where tblQuestScore.ScoreID = 1
    and tblQuestPlayInventory.InventoryID = 1;
    
    
-- delete statments

delete from tblQuestScore;
delete from tblQuestPlayInventory;
delete from tblQuestPlay;
delete from tblChat;
delete from tblQuestTileAsset;
delete from tblQuestMapTile;
delete from tblQuestMap;
delete from tblQuest;
delete from tblAsset;
delete from tblUser;

    
end //
delimiter ;


call ddlWizardQuestDB();
call dmlWizardQuestDB();



