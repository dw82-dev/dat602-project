drop database if exists WizardQuest;
create database WizardQuest;
use WizardQuest;

set global transaction isolation level read committed;
show global variables like '%isolation%';

drop user if exists 'wizard'@'localhost';
create user 'wizard'@'localhost' identified by '55555';
grant all on WizardQuest.* to 'wizard'@'localhost';



drop procedure if exists ddlWizardQuestDB;
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
    
	create table tblMap(
	MapID int not null auto_increment primary key,
    QuestID int not null,
    xMax int not null,
    yMax int not null,
    foreign key (QuestID) references tblQuest(QuestID) on delete cascade
    );
    
	create table tblTile(
	TileID int not null auto_increment primary key,
    MapID int not null,
    xPosition int not null,
    yPosition int not null,
    TileActive bool,
    foreign key (MapID) references tblMap(MapID) on delete cascade
    );
    
	create table tblAsset(
	AssetID int not null auto_increment primary key,
    AssetName varchar(30) not null,
    AssetDescription varchar(50) not null,
    AssetValue int not null
    );
    
	create table tblTileAsset(
	TileAssetID int not null auto_increment primary key,
	TileID int not null,
    AssetID int not null,
    foreign key (TileID) references tblTile(TileID) on delete cascade,
    foreign key (AssetID) references tblAsset(AssetID)
    );
    
	create table tblSession(
	SessionID int not null auto_increment primary key,
    UserID int not null,
    MapID int,
    TileID int,
    QuestID int,
    PlayerNumber int,
    Score int,
    SessionActive bool not null,
    foreign key (UserID) references tblUser(UserID) on delete cascade,
    foreign key (MapID) references tblMap(MapID) on delete cascade,
    foreign key (TileID) references tblTile(TileID),
    foreign key (QuestID) references tblQuest(QuestID)
    );
    
    create table tblChat(
	ChatID int not null auto_increment primary key,
    QuestID int not null,
    UserID int not null,
    Message varchar(255),
    foreign key (QuestID) references tblQuest(QuestID) on delete cascade,
    foreign key (UserID) references tblUser(UserID) on delete cascade
    );
    
	create table tblInventory(
	InventoryID int not null auto_increment primary key,
    UserID int not null,
    SessionID int not null,
    AssetID int,
    Quantity int,
    foreign key (UserID) references tblUser(UserID) on delete cascade,
    foreign key (SessionID) references tblSession(SessionID) on delete cascade,
    foreign key (AssetID) references tblAsset(AssetID)
    );
    
end //
delimiter ;

drop procedure if exists dmlWizardQuestDB;
delimiter //
create procedure dmlWizardQuestDB()
begin

	-- insert statements for assets
    insert into tblAsset (AssetName, AssetDescription, AssetValue)
	values
    ('Gold', 'Wizard Gold', '1000'),
    ('Wand', 'Wizard Wand', '500'),
    ('Gem', 'Spell Gem', '500'),
    ('Cloak', 'Invisibility Cloak', '500'),
    ('Destoryed', 'Spell Book Destroyed', '-500'),
    ('Area', 'Magic Dead Area', '-500');

	-- test data new user
	call userRegistration('Daniel', '1234', 'daniel@emailaddress.com');
    call userRegistration('Bob', '1234', 'bob@emailaddress.com');
    call userRegistration('Sally', '1234', 'sally@emailaddress.com');
    call userRegistration('Alexis', '1234', 'alexis@emailaddress.com');
    call userRegistration('Trevor', '1234', 'trevor@emailaddress.com');
    call userRegistration('Sam', '1234', 'sam@emailaddress.com');
    call userRegistration('Adel', '1234', 'adel@emailaddress.com');
    call userRegistration('Xavier', '1234', 'xavier@emailaddress.com');
    call userRegistration('Tom', '1234', 'tom@emailaddress.com');
    call userRegistration('Jerry', '1234', 'jerry@emailaddress.com');
    call userRegistration('Emma', '1234', 'emma@emailaddress.com');
    
    -- test data modify user
    call administratorModify('1', 'Daniel', '1234', 'daniel@emailaddress.com', '0', false, true, '1000');
    call administratorModify('3', 'Sally', '1234', 'sally@emailaddress.com', '0', false, false, '10500');
    call administratorModify('2', 'Bob', '1234', 'bob@emailaddress.com', '0', false, false, '27500');
    call administratorModify('4', 'Alexis', '1234', 'alexis@emailaddress.com', '0', false, false, '3000');
    call administratorModify('5', 'Trevor', '1234', 'trevor@emailaddress.com', '0', false, false, '17000');
    
	-- test data new quest
    call newQuest('2', 'Bobs Quest');
    call newQuest('3', 'Sallys Quest');
    call newQuest('6', 'Sams Quest');
    
    -- login to test datagrid
    call userLogin('Bob', 1234);
    call userLogin('Sally', 1234);
    call userLogin('Alexis', 1234);
    
    -- test data join quest
    call joinQuest('1', '1');
    call joinQuest('5', '1');
    call joinQuest('7', '2');
    call joinQuest('9', '1');
    
    -- inventory data add for console app demo
    update tblInventory
    set Quantity = 7
    where UserID = 3
    and SessionID = 2
    and AssetID = 1;
    
    update tblInventory
    set Quantity = 4
    where UserID = 3
    and SessionID = 2
    and AssetID = 2;
    
    update tblInventory
    set Quantity = 3
    where UserID = 3
    and SessionID = 2
    and AssetID = 3;
    
    update tblInventory
    set Quantity = 1
    where UserID = 3
    and SessionID = 2
    and AssetID = 4;

end //
delimiter ;

drop procedure if exists userRegistration;
delimiter //
create procedure userRegistration(in pUserName varchar(30), in pUserPassword varchar(20), pEmail varchar(50))
begin
	if exists (select *
		from tblUser
        where UserName = pUserName) then
	begin
		select 'Username' as message;
    end;    
	else
		insert into tblUser(UserName, UserPassword, Email, LoginAttempts, UserLocked, UserOnline, Administrator, TotalScore)
		values (pUserName, pUserPassword, pEmail, 0, 0, 0, 0, 0);
		select 'Success' as message;
	end if;
end //
delimiter ;

drop procedure if exists userLogin;
delimiter //
create procedure userLogin(in pUserName varchar(30), in pUserPassword varchar(20))
begin

	declare verifyUser int default null;
    
		if exists (select UserID  -- username is existing
			from tblUser
			where UserName = pUserName) then
				begin
					select UserID
					from tblUser
					where UserName = pUserName
					and UserPassword = pUserPassword
					into verifyUser;
						if verifyUser is null then -- invalid password                       
							update tblUser
							set LoginAttempts = LoginAttempts +1
							where UserName = pUserName;
								if (select UserID -- failed logins less than five
									from tblUser
                                    where UserName = pUserName
                                    and LoginAttempts < 5) then
									select 'Password' as message;
								else -- failed logins 5 or more
									update tblUser
                                    set UserLocked = true
                                    where UserName = pUserName;
									select 'Locked' as message;
								end if;
                        else
							if (select UserID -- valid username and password but account is locked
								from tblUser
								where UserName = pUserName
								and UserLocked = true) then
                                select 'Locked' as message;
							else -- valid username and password, user now online
								update tblUser
								set LoginAttempts = 0, UserOnline = true
								where UserName = pUserName;
									if exists	(select UserID
												from tblUser
												where UserName = pUserName
												and Administrator = true) then
												select 'Administrator' as message;
									else
												select 'Success' as message;
									end if;
							end if;
                        end if;
				end;
        else -- username does not exists
			select 'Username' as message;
		end if;

end //
delimiter ;

drop procedure if exists userLogout
delimiter //
create procedure userLogout(in pUserName varchar(30))
begin
	update tblUser
    set UserOnline = false
    where UserName = pUserName;
    select 'Offline' as message;
end //
delimiter ;

drop procedure if exists userDelete
delimiter //
create procedure userDelete(in pUserName varchar(30), in pUserPassword varchar(20))
begin

	declare verifyUser int default null;
    
    select UserID
    from tblUser
    where UserName = pUserName
    and UserPassword = pUserPassword
    into verifyUser;
    
		if verifyUser is null then
			select 'Fail' as message;
		else
			delete from tblUser
            where UserName = pUserName;
			select 'Success' as message;
		end if;
end //
delimiter ;

drop procedure if exists newQuest
delimiter //
create procedure newQuest(in pUserID int, in pQuestName varchar(50))
begin

	declare maxUsers int default 4;
    declare activePlayer int default 1;
    declare questStatus int default 1;
    declare playerNumber int default 1;
    declare score int default 0;
    declare newQuestID int default null;
    declare newMapID int default null;
    declare homeTileID int default null;
    declare endTileID int default null;
    declare rowMin int default 1;
    declare rowMax int default 20;
    declare colMin int default 1;
    declare colMax int default 20;
    declare assetCount int default 0;
    declare assetTile int default null;
    declare assetType int default 1;
    declare newSessionID int default null;
    
    if exists	(select QuestName
				from tblQuest
                where QuestName = pQuestName) then
                
                select 'Invalid Quest Name' as message;
	else
				-- creates quest
				insert into tblQuest(QuestName, MaxUsers, ActivePlayer, QuestStatus)
				values (pQuestName, maxUsers, activePlayer, questStatus);
				
				set newQuestID = last_insert_id();
				
				-- creates map instance
				insert into tblMap(QuestID, xMax, yMax)
				values(newQuestID, rowMax, colMax);
				
				set newMapID = last_insert_id();
				
				-- creates map tiles
				tileRow: loop
					tileCol : loop
						insert into tblTile(MapID, xPosition, yPosition, TileActive)
						values (newMapID, rowMin, colMin, true);
						set colMin = colMin + 1;
						if colMin > 20 then
							set colMin = 1;
							leave tileCol;
						end if;
					end loop tileCol;
				set rowMin = rowMin + 1;
				if rowMin > 20 then
					leave tileRow;
				end if;
				end loop tileRow;
				
				-- finds new home tileid
				select TileID
				into homeTileID
				from tblTile
				where xPosition = 1 and yPosition = 1 and MapID = newMapID;
				
				-- finds new end tileid
				select TileID
				into endTileID
				from tblTile
				where xPosition = 20 and yPosition = 20 and MapID = newMapID;
				
				-- creates all game assests on random tiles excluding home tile
				getAsset: loop
						addAsset: loop
							set assetTile =	(select floor(rand()*(endTileID-homeTileID)+homeTileID));
							if not exists 	(select * 
											from tblTileAsset
											where TileID = assetTile) then
											set assetCount = assetCount + 1;
											insert into tblTileAsset(TileID, AssetID)
											values (assetTile, assetType);
											
							end if;
											if assetCount = 25 then
												set assetCount = 0;
												leave addAsset;
											end if;
						end loop addAsset;
				set assetType = assetType + 1;
					if assetType > 6 then
						set assetType = 1;
						leave getAsset;
					end if;
				end loop getAsset;
						
				-- creates game session
				insert into tblSession(UserID, QuestID, MapID, TileID, PlayerNumber, Score, SessionActive)
				values (pUserID, newQuestID, newMapID, homeTileID, playerNumber, score, true);
				
				set newSessionID = last_insert_id();
				
				-- creates user inventory as point scoring assest for session
				while assetType <= 4 do
					insert into tblInventory(AssetID, UserID, SessionID, Quantity)
					values (assetType, pUserID, newSessionID, 0);
					set assetType = assetType + 1;
				end while;
				
				select 'New Quest Active' as message;
	end if;
end //
delimiter ;

drop procedure if exists joinQuest
delimiter //
create procedure joinQuest(in pUserID int, in pQuestID int)
begin

	declare currentCount int default null;
    declare maxCount int default null;
    declare playerNumber int default null;
    declare sessionMapID int default null;
    declare homeTileID int default null;
    declare score int default 0;
    declare newSessionID int default null;
    declare assetType int default 1;
    declare existingSessionID int default null;
    declare existingTileID int default null;
    declare onlineCount int default null;
    
    set	sessionMapID = 	(select MapID 
						from tblMap 
						where QuestID = pQuestID);
                                        
    set homeTileID = 	(select TileID	
						from tblTile 
						where xPosition = 1 
						and yPosition = 1 
						and MapID = sessionMapID);
                        
	set onlineCount = 	(select count(*) 
						from tblSession 
						where QuestID = pQuestID
                        and SessionActive = true);
                                        
    -- check if new or returning user
    if exists	(select SessionID
				from tblSession
				where UserID = pUserID
                and QuestID = pQuestID) then
                
                set existingSessionID =	(select SessionID
										from tblSession
										where UserID = pUserID
										and QuestID = pQuestID);
                 
                 set existingTileID =	(select TileID
										from tblSession
										where UserID = pUserID
										and QuestID = pQuestID);
                                        
                -- update user session to active
                update tblSession
                set SessionActive = true
                where SessionID = existingSessionID;
				
                -- check if last tile location is user free
                if exists	(select TileID
							from tblTile
                            where TileID = existingTileID
							and TileActive = true) then
                            
                            -- sets tile as in-use, if <> home tile
                            update tblTile
                            set TileActive = false
                            where TileID = existingTileID
							and TileID <> homeTileID;
							
                            -- if only player currently in quest, set as active player 
                            if onlineCount = 0 then
								update tblQuest
                                set ActivePlayer =	(select PlayerNumber
													from tblSession
                                                    where UserID = pUserID
                                                    and QuestID = pQuestID)
								where QuestID = pQuestID;
							end if;
                            
							select 'Welcome Back' as message;
				else
							-- link to rejoinMove procedure with user input
							select 'Previous Tile In-Use - Choose Another' as message;
                end if;
	else
				-- check if user can join
				set 	currentCount = 	(select count(*) 
										from tblSession 
										where QuestID = pQuestID);
				set		maxCount = 		(select MaxUsers 
										from tblQuest 
										where QuestID = pQuestID);
				
				if currentCount < maxCount then
                
					set playerNumber = 	(select count(*) 
										from tblSession 
										where QuestID = pQuestID) + 1;
					
                    -- starts a new session
					insert into tblSession(UserID, QuestID, MapID, TileID, PlayerNumber, Score, SessionActive)
					values (pUserID, pQuestID, sessionMapID, homeTileID, playerNumber, score, true);
					
					set newSessionID = last_insert_id();
					
					-- creates user inventory as point scoring assest for session
					while assetType <= 4 do
						insert into tblInventory(AssetID, UserID, SessionID, Quantity)
						values (assetType, pUserID, newSessionID, 0);
						set assetType = assetType + 1;
					end while;
                    
                    -- if only player currently in quest, set as active player 
                            if onlineCount = 0 then
								update tblQuest
                                set ActivePlayer = playerNumber
								where QuestID = pQuestID;
							end if;
					
					select 'Quest Joined' as message;
				else
					select 'Quest Full - Try Another' as message;
				end if;
	end if;
end //
delimiter ;

drop procedure if exists userMove;
delimiter //
create procedure userMove(pSessionID int, pUserID int, pxPosition int, pyPosition int)
begin
	
    declare currentMapID int default null;
    declare homeTileID int default null;
    declare startTileID int default null;
    declare targetTileID int default null;
    declare currentQuestID int default null;
    declare currentCount int default null;
    declare nextPlayer int default null;
    
    set currentQuestID = 	(select QuestID
							from tblSession
                            where SessionID = pSessionID);

    set currentMapID =	(select MapID
						from tblSession
                        where SessionID = pSessionID
                        and UserID = pUserID);
	
    set homeTileID =	(select TileID
						from tblTile
                        where MapID = currentMapID
						and xPosition = 1 and yPosition = 1);
	
    set startTileID =	(select TileID
						from tblSession
                        where SessionID = pSessionID
                        and UserID = pUserID);	
    
    -- checks if user can move                   
    if exists	(select PlayerNumber
				from tblSession
                where PlayerNumber =	(select ActivePlayer
										from tblQuest
                                        where QuestID = currentQuestID)
				and SessionID = pSessionID) then
		
        -- validates new tile location
		if exists	(select *
					from tblTile as t3
					where (t3.xPosition = pxPosition and t3.yPosition = pyPosition)
					and t3.TileID in 	(select t2.TileID
										from tblSession as s
											join tblTile as t
											on s.TileID = t.TileID
											join tblTile as t2
											on t.TileID <> t2.TileID
										where t.MapID = currentMapID
										and ((t2.xPosition = t.xPosition + 1) or (t2.xPosition = t.xPosition -1) or (t2.xPosition = t.xPosition))
										and	((t2.yPosition = t.yPosition + 1) or (t2.yPosition = t.yPosition -1) or (t2.yPosition = t.yPosition))
										and	s.SessionID = pSessionID
										and	s.UserID = pUserID)) then
										
					set targetTileID =	(select TileID
										from tblTile
										where xPosition = pxPosition and yPosition = pyPosition
										and MapID = currentMapID);
										
					-- check to see if tile is available
					if exists	(select TileID
								from tblTile
								where TileID = targetTileID
								and TileActive = true) then
								
								update tblSession
								set TileID = targetTileID
								where SessionID = pSessionID;
										
								-- sets new tile if <> home tile so no other users can choose it
								update tblTile
								set TileActive = false
								where TileID = targetTileID
								and TileID <> homeTileID;
										
								-- sets old tile so other users can choose it
								update tblTile
								set TileActive = true
								where TileID = startTileID;
								
								-- score points
								if exists	(select TileID
											from tblTileAsset
											where TileID = targetTileID) then
																	
											-- updates inventory if item is positive value
											update tblInventory
											set Quantity = Quantity + 1
											where AssetID =	(select AssetID
															from tblTileAsset
															where TileID = targetTileID);
											
											-- updates score
											update tblSession
											set Score = Score +	(select a.AssetValue
																from tblAsset as a
																join tblTileAsset as t
																on a.AssetID = t.AssetID
																where t.TileID = targetTileID)
											where SessionID = pSessionID;
																
											-- removes asset from map
											delete from tblTileAsset
											where TileID = targetTileID;
								end if;
								
								-- Update player turn 
								set currentCount = 	(select count(*) 
													from tblSession 
													where QuestID = currentQuestID);
								
								set nextPlayer =	(select PlayerNumber
													from tblSession
													where SessionID = pSessionID);
								
								-- finds next player online in current quest
								findNextPlayer: loop
								
									-- get next player number
									if nextPlayer < CurrentCount then
										set nextPlayer = nextPlayer + 1;
									else
										set nextPlayer = 1;
									end if;
									
									-- check if nextPlayer is online
									if exists	(select PlayerNumber
												from tblSession
												where QuestID = currentQuestID
												and PlayerNumber = nextPlayer
												and SessionActive = true) then
												
												update tblQuest
												set ActivePlayer = nextPlayer
												where QuestID = currentQuestID;
												
												leave findNextPlayer;
									end if;
								end loop findNextPlayer;
								
								select 'Valid Move' as message;
					else
								select 'Tile In Use' as message;
					end if;
		else
					select 'Invalid Move' as message;
		end if;
    else
		select 'Wait for your turn!' as message;
	end if;
    
    -- quest validation users, scores, and assets
	call checkQuest(pUserID, currentQuestID, currentMapID);
                                        
end //
delimiter ;

drop procedure if exists rejoinMove;
delimiter //
create procedure rejoinMove(pSessionID int, pUserID int, pQuestID int, pxPosition int, pyPosition int)
begin
	
    declare currentMapID int default null;
    declare homeTileID int default null;
    declare startTileID int default null;
    declare targetTileID int default null;
    declare currentCount int default null;
    declare nextPlayer int default null;
    
    set currentMapID =	(select MapID
						from tblSession
                        where SessionID = pSessionID
                        and UserID = pUserID);
	
    set homeTileID =	(select TileID
						from tblTile
                        where MapID = currentMapID
						and xPosition = 1 and yPosition = 1);
	
    set startTileID =	(select TileID
						from tblSession
                        where SessionID = pSessionID
                        and UserID = pUserID);	
    
	if exists	(select *
				from tblTile as t3
				where (t3.xPosition = pxPosition and t3.yPosition = pyPosition)
                and t3.TileID in 	(select t2.TileID
									from tblSession as s
										join tblTile as t
										on s.TileID = t.TileID
										join tblTile as t2
										on t.TileID <> t2.TileID
                                    where t.MapID = currentMapID
									and ((t2.xPosition = t.xPosition + 1) or (t2.xPosition = t.xPosition -1) or (t2.xPosition = t.xPosition))
									and	((t2.yPosition = t.yPosition + 1) or (t2.yPosition = t.yPosition -1) or (t2.yPosition = t.yPosition))
									and	s.SessionID = pSessionID
									and	s.UserID = pUserID)) then
                                    
				set targetTileID =	(select TileID
									from tblTile
                                    where xPosition = pxPosition and yPosition = pyPosition
                                    and MapID = currentMapID);
                                    
                -- check to see if tile is available
				if exists	(select TileID
							from tblTile
							where TileID = targetTileID
                            and TileActive = true) then
                            
							update tblSession
							set TileID = targetTileID
                            where SessionID = pSessionID;
									
							-- sets new tile if <> home tile so no other users can choose it
							update tblTile
							set TileActive = false
							where TileID = targetTileID
							and TileID <> homeTileID;
                            
                            -- score points
                            if exists	(select TileID
										from tblTileAsset
                                        where TileID = targetTileID) then
                                        
                                        -- updates inventory if item is positive value
                                        update tblInventory
                                        set Quantity = Quantity + 1
                                        where AssetID =	(select AssetID
														from tblTileAsset
                                                        where TileID = targetTileID);
										
                                        -- updates score
                                        update tblSession
                                        set Score = Score +	(select a.AssetValue
															from tblAsset as a
                                                            join tblTileAsset as t
                                                            on a.AssetID = t.AssetID
                                                            where t.TileID = targetTileID)
										where SessionID = pSessionID;
                                                            
										-- removes asset from map
                                        delete from tblTileAsset
                                        where TileID = targetTileID;
							end if;
                            
                            -- Update player turn 
                            set currentCount = 	(select count(*) 
												from tblSession 
												where QuestID = pQuestID);
							
                            set nextPlayer =	(select PlayerNumber
												from tblSession
												where SessionID = pSessionID);
                            
                            -- finds next player online in current quest
							findNextPlayer: loop
                            
								-- get next player number
								if nextPlayer < CurrentCount then
									set nextPlayer = nextPlayer + 1;
								else
									set nextPlayer = 1;
								end if;
								
								-- check if nextPlayer is online
                                if exists	(select PlayerNumber
											from tblSession
											where QuestID = pQuestID
                                            and PlayerNumber = nextPlayer
                                            and SessionActive = true) then
                                            
                                            update tblQuest
                                            set ActivePlayer = nextPlayer
                                            where QuestID = pQuestID;
                                            
                                            leave findNextPlayer;
								end if;
							end loop findNextPlayer;
                            
							select 'Valid Move' as message;
				else
							select 'Tile In Use' as message;
				end if;
	else
				select 'Invalid Move' as message;
    end if;
    
    -- quest validation users, scores, and assets
	call checkQuest(pUserID, QuestID, (select MapID
										from tblSession
                                        where UserID = pUserID
                                        and QuestID = pUserID));
end //
delimiter ;

drop procedure if exists userChat
delimiter //
create procedure userChat(pUserID int, pQuestID int, pMessage varchar(255))
begin
	-- verifies if quest is still active
    if exists	(select QuestID
				from tblQuest
                where QuestID = pQuestID) then
                
                -- sends chat
                insert into tblChat(UserID, QuestID, Message)
				values(pUserID, pQuestID, pMessage);
				select pMessage as message;
	else
				select 'Chat Unavilable - Your Quest Has Ended' as message;
	end if;
end //
delimiter ;

drop procedure if exists leaveQuest
delimiter //
create procedure leaveQuest(pUserID int, pQuestID int)
begin
	
    declare currentCount int default null;
    declare onlineCount int default null;
    declare nextPlayer int default null;
    
	-- verifies session
	if exists	(select SessionID
				from tblSession
				where UserID = pUserID
				and QuestID = pQuestID
                and SessionActive = true) then
                
                -- leaves quest
				update tblSession
				set SessionActive = false
				where UserID = pUserID
				and QuestID = pQuestID;
				
                -- count players
                set currentCount = 	(select count(*) 
									from tblSession 
									where QuestID = pQuestID);
				
                -- count players online
                set onlineCount =	(select count(*) 
									from tblSession 
									where QuestID = pQuestID
                                    and SessionActive = true);
                
                -- updates tile for game play
				update tblTile
				set TileActive = true
				where TileID = 	(select TileID
								from tblSession
								where UserID = pUserID
								and QuestID = pQuestID);
                                
				-- check if player leaves during their turn and if any remaining players online
                if exists	(select PlayerNumber
							from tblSession
                            where UserID = pUserID
                            and QuestID = pQuestID
                            and PlayerNumber =	(select ActivePlayer
												from tblQuest
                                                where QuestID = pQuestID)) and onlineCount > 0 then
							
                            set nextPlayer =	(select PlayerNumber
												from tblSession
												where UserID = pUserID
                                                and QuestID = pQuestID);
                                                
                            -- finds next player online in current quest
							findNextPlayer: loop
                            
								-- get next player number
								if nextPlayer < CurrentCount then
									set nextPlayer = nextPlayer + 1;
								else
									set nextPlayer = 1;
								end if;
								
								-- check if nextPlayer is online
                                if exists	(select PlayerNumber
											from tblSession
											where QuestID = pQuestID
                                            and PlayerNumber = nextPlayer
                                            and SessionActive = true) then
                                            
                                            update tblQuest
                                            set ActivePlayer = nextPlayer
                                            where QuestID = pQuestID;
                                            
                                            leave findNextPlayer;
								end if;
							end loop findNextPlayer;
                end if;
                
				select 'Quest Left' as message;
	else
				select 'Invalid' as message;
	end if;
end //
delimiter ;

drop procedure if exists administratorAdd;
delimiter //
create procedure administratorAdd(pUserName varchar(30), pUserPassword varchar(20), pEmail varchar(50), pAdministrator bool)
begin

if exists (select *
		from tblUser
        where UserName = pUserName) then
	begin
		select 'Username' as message;
    end;    
	else
		insert into tblUser(UserName, UserPassword, Email, LoginAttempts, UserLocked, UserOnline, Administrator, TotalScore)
		values (pUserName, pUserPassword, pEmail, 0, false, false, pAdministrator, 0);
		select 'Success' as message;
	end if;

end //
delimiter ;

drop procedure if exists administratorModify;
delimiter //
create procedure administratorModify(pUserID int, pUserName varchar(30), pUserPassword varchar(20), pEmail varchar(50), pLoginAttempts int, pUserLocked bool, pAdministrator bool, pTotalScore int)
begin

	declare modifyUser int default null;

	if exists 	(select *
				from tblUser
                where UserName = pUserName
                and UserID <> pUserID) then
				select 'Username' as message;
	else
				set modifyUser =	(select UserID
									from tblUser
									where UserID = pUserID);
				
									if modifyUser is null then
										select 'UserID' as message;
									else                   
										update tblUser
										set 	UserName = pUserName,
												UserPassword = pUserPassword,
												Email = pEmail,
												LoginAttempts = pLoginAttempts,
												UserLocked = pUserLocked,
												Administrator = pAdministrator,
												TotalScore = pTotalScore
										where	UserID = pUserID;
										select 'Success' as message;
									end if;
	end if;
end //
delimiter ;

drop procedure if exists administratorDelete;
delimiter //
create procedure administratorDelete(pUserID int)
begin

	declare deleteUser int default null;
    
    select UserID
    into deleteUser
    from tblUser
    where UserID = pUserID;
    
    if deleteUser is null then
		select 'UserID' as message;
	else		
		delete from tblUser
		where UserID = pUserID;
		select 'Success' as message;
	end if;

end //
delimiter ;

drop procedure if exists administratorKill;
delimiter //
create procedure administratorKill(pQuestID int)
begin
	if exists	(select QuestID
				from tblQuest
                where QuestID = pQuestID) then
                
				delete from tblQuest
				where QuestID = pQuestID;
                
				select 'Success' as message;
    else
				select 'QuestID' as message;
	end if;
end //
delimiter ;

drop procedure if exists getAdministratorQuest;
delimiter //
create procedure getAdministratorQuest()
begin
	select QuestID, QuestName
    from tblQuest
    where QuestStatus = true;
end //
delimiter ;

drop procedure if exists checkQuest
delimiter //
create procedure checkQuest(pUserID int, pQuestID int, pMapID int)
begin
	
    declare questScore int default null;
    declare assetCount int default null;
    declare questWinner int default null;
    
    set questScore = 	(select Score
						from tblSession
                        where UserID = pUserID
                        and QuestID = pQuestID);
                        
    set assetCount = 	(select count(a.TileID)
						from tblTileAsset as a
						join tblTile as t
						on a.TileID = t.TileID
						where MapID = pMapID
						and a.AssetID <= 4);
	
    set questWinner =	(select UserID
						from tblSession
						where QuestID = pQuestID
						and Score >= 10000);
	
    -- checks if user died and leaves quest 
    if questScore < 0 then
        update tblSession
		set SessionActive = false
		where UserID = pUserID
		and QuestID = pQuestID;
				
		update tblTile
		set TileActive = true
		where TileID = 	(select TileID
						from tblSession
						where UserID = pUserID
						and QuestID = pQuestID);
				
		select 'You Died - Your Quest Has Ended' as message;
	end if;
    
    -- checks new score can win and if any assets are left in the quest
    if	questWinner is not null or assetCount <= 0  then
		-- get winner if null and no more assets on map
		set questWinner = 	(select UserID
							from tblSession
							where QuestID = pQuestID
							and Score = (select max(Score)
										from tblSession
										where QuestID = pQuestID));
                            
        -- update all users total score from quest if value is positive
        update tblUser as u
        join tblSession as s
        on u.UserID = s.UserID
        set u.TotalScore = u.TotalScore + s.Score
        where s.QuestID = pQuestID
        and s.Score > 0;
        
        -- end quest
        delete from tblQuest
		where QuestID = pQuestID;
                
        select concat('Your Quest has ended, ',	(select UserName
												from tblUser
												where UserID = questWinner), ' Wins!') as message;
	end if;
end //
delimiter ;

drop procedure if exists getUserID;
delimiter //
create procedure getUserID(in pUserName varchar(30))
begin
	declare currentUserID int default null;
    
	select UserID
    from tblUser
    where UserName = pUserName
    into currentUserID;
    
    select currentUserID as message;
end //
delimiter ;

drop procedure if exists getAllUsers;
delimiter //
create procedure getAllUsers()
begin
	select UserID, UserName, UserPassword, Email, LoginAttempts, TotalScore, UserLocked, Administrator
    from tblUser;
end //
delimiter ;

drop procedure if exists getOnlineUsers;
delimiter //
create procedure getOnlineUsers()
begin
	select UserName
    from tblUser
    where UserOnline = true;
end //
delimiter ;

drop procedure if exists getActiveQuest;
delimiter //
create procedure getActiveQuest(in pUserID int)
begin
	select QuestName
    from tblQuest
    where QuestStatus = true
    and QuestID <>	(select QuestID
					from tblSession
                    where UserID = pUserID);
end //
delimiter ;

drop procedure if exists getUserActiveQuest;
delimiter //
create procedure getUserActiveQuest(in pUserID int)
begin
    select QuestID, QuestName
    from tblQuest
    where QuestStatus = true
    and QuestID  in	(select QuestID
					from tblSession
                    where UserID = pUserID
                    and Score >= 0);
end //
delimiter ; 

drop procedure if exists getHighScores;
delimiter //
create procedure getHighScores()
begin
	select UserName, TotalScore
    from tblUser
    order by TotalScore desc
    limit 10;
end //
delimiter ;

drop procedure if exists getUserInventory
delimiter //
create procedure getUserInventory(pSessionID int)
begin
    select a.AssetDescription as Item, i.Quantity
	from tblInventory as i
	join tblAsset as a
	on i.AssetID = a.AssetID
	where SessionID = pSessionID;
end //
delimiter ;


call ddlWizardQuestDB();
call dmlWizardQuestDB();


-- call leaveQuest(2, 1);

-- call userMove(1, 2, 1, 2);
-- call leaveQuest(2, 1);
-- call userMove(4, 1, 1, 2);
-- call joinQuest(2, 1);

-- call testmoves();

-- call getUserActiveQuest(1);
-- call getUserID('Daniel');
-- call getActiveQuest(1);