SQLite format 3   @     z             `                                                 z -�   �     ��������                                                                                                                                                                                                                                     /C indexsqlite_autoindex_barangay_1barangay�Q�tabletowntownCREATE TABLE `town` (
  `id` INT NOT NULL,
  `townname` VARCHAR(255) NOT NULL,
  `province_id` INT NOT NULL,
  `status` SMALLINT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_town_province`
    FOREIGN KEY (`province_id`)
    REFERENCES `province` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)'; indexsqlite_autoindex_town_1town�5�=tableprovinceprovinceCREATE TABLE `province` (
  `id` INT NOT NULL,
  `provincename` VARCHAR(255) NOT NULL,
  `status` SMALLINT NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`))/C index� �          	             ��������}k]P=&                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           '		Sorsogon City+		Santa Magdalena#		Prieto Diaz		Pilar		Matnog
!		
Magallanes				Juban		Irosin		Gubat		Donsol		Castilla		Casiguran		Bulusan		Bulan			Barcelona
   � ���������������                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

				   ) �������oaS=-��������r]I9)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         	Tongdol	Tinampo#	Tabon-Tabon%	Sto. Domingo	San Pedro!	San Julian	San Juan!	San Isidro#	San Agustin	Salvacion	Patag	Monbon	Mapaso	Macawayan	Liang	Gumapia'	Gulang-Gulang	Gabao
	
Cogon			Cawayan	Casini	Carriedo	Bulawan!	Buenavista	Bolos	Batang	Bagsangan		Bacolod
   Z ���������������������~xrlf`Z                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

				   s s                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         �
	)-;;osca-001irosinteacherroman catholic999filipinoBSBAcomputer hacking  2013-12-18 16:22:45.000jhoe2013-12-18 16:22:55.000jhoe
   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		osca-001    "  "-V�#e              ��stableuseruser
CREATE TABLE `user` (
  `userid` INT NOT NULL,
  `username` VARCHAR(45) NOT NULL,
  `loginid` VARCHAR(45) NOT NULL,
  `password` TEXT NOT NULL,
  `saltvalue` TEXT NOT NULL,
  `block` TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (`userid`))'; indexsqlite_autoindex_user_1user�	�}tableuser_roleuser_roleCREATE TABLE `user_role` (
  `roleid` SMALLINT NOT NULL,
  `rolename` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`roleid`))1
E indexsqlite_autoindex_user_role_1user_role�Z%%�wtableuser_to_roleuser_to_roleCREATE TABLE `user_to_role` (
  `roleid` SMALLINT NOT NULL,
  `userid` INT NOT NULL,
  PRIMARY KEY (`roleid`, `userid`),
  CONSTRAINT `fk_user_to_roles_users`
    FOREIGN KEY (`userid`)
    REFERENCES `user` (`userid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_to_roles_user_roles`
    FOREIGN KEY (`roleid`)
    REFERENCES `user_role` (`roleid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)    �  �!�����@                                       �	�}tableuser_roleuser_roleCREATE TABLE `user_role` (
  `roleid` SMALLINT NOT NULL,
  `�_�tablebarangaybarangayCREATE TABLE `barangay` (
  `id` INT NOT7K% indexsqlite_autoindex_user_to_role_1user_to_role�--�itablemember_to_familymember_to_familyCREATE TABLE `member_to_family` (
  `members_id` INT NOT NULL,
  `members_sc_id` VARCHAR(45) NOT NULL,
  `familyrecords_id` INT NOT NULL,
  `relationship` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`members_id`, `members_sc_id`, `familyrecords_id`),
  CONSTRAINT `fk_member_to_family_members1`
    FOREIGN KEY (`members_id` , `members_sc_id`)
    REFERENCES `member_detail` (`id` , `sc_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_member_to_family_familyrecords1`
    FOREIGN KEY (`familyrecords_id`)
    REFERENCES `family_record` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)?S- indexsqlite_autoindex_member_to_family_1member_to_family   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 3	E	jhoejhoeyym5pwK0d80DnlBdgySEtjbMwYs=cryBn+Vd
   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		   � ��                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     encoder	'administrator
   � ��                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          		   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		
   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 			    ��                                                                                                                                                                                                                                                                                                                                                                          9M'9M' indexsqlite_autoindex_member_detail_1member_detail�''�Otablefamily_recordfamily_recordCREATE TABLE [family_record] (
  [id] INT NOT NULL, 
  [firstname] VARCHAR(45) NOT NULL, 
  [middlename] VARCHAR(45) NOT NULL, 
  [lastname] VARCHAR(45) NOT NULL, 
  [gender] VARCHAR(45), 
  [civilstatus] VARCHAR(45), 
  [mobile] VARCHAR(45), 
  [dob] DATE, 
  [created] DATETIME NOT NULL, 
  [created_by] VARCHAR(45) NOT NULL, 
  [modified] DATETIME NOT NULL, 
  [modified_by] VARCHAR(45) NOT NULL, 
  CONSTRAINT [sqlite_autoindex_family_record_1] PRIMARY KEY ([id]))9M' indexsqlite_autoindex_family_record_1family_record                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 � ���                                                       �cc�9tabletemp_table_27E74EF9F4E64890AD24B841846B1C72temp_table_27E74EF9F4E64890AD24B841846B1C72CREATE TABLE "temp_table_27E74EF9F4E64890AD24B841846B1C72" (
  [members_id] INT NOT NULL, 
  [members_sc_id] VARCHAR(45) NOT NULL, 
  [birthplace] VARCHAR(255) NOT NULL, 
  [occupation] VARCHAR(45) NOT NULL, 
  [religion] VARCHAR(255) NOT NULL, �`�tableprovinceprovinceCREATE TABLE [province] (
  [id] INT NOT NULL, 
  [provincename] VARCHAR(255) NOT NULL, 
  [state] SMALLINT NOT NULL DEFAULT 1, 
  CONSTRAINT [sqlite_autoindex_province_1] PRIMARY KEY ([id]))/C indexsqlite_autoindex_province_1province�D�ktabletowntownCREATE TABLE [town] (
  [id] INT NOT NULL, 
  [townname] VARCHAR(255) NOT NULL, 
  [province_id] INT NOT NULL CONSTRAINT [fk_town_province] REFERENCES [province]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  [state] SMALLINT NOT NULL, 
  CONSTRAINT [sqlite_autoindex_town_1] PRIMARY KEY ([id]))   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ^	!	!!osca-001seniorcscitizen1950-01-01mmarried123active2013-12-12jhoe2013-12-12jhoe
   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		osca-001    � � �                                                                                                                               CW1 indexsqlite_autoindex_member_information_1member_information   �j''�tablemember_detailmember_detailCREATE TABLE [mem�j''�tablemember_detailmember_detailCREATE TABLE [member_detail] (
  [id] INT NOT NULL, 
  [sc_id] VARCHAR(45) NOT NULL, 
  [firstname] VARCHAR(255) NOT NULL, 
  [middlename] VARCHAR(45) NOT NULL, 
  [lastname] VARCHAR(45) NOT NULL, 
  [dob] DATE NOT NULL, 
  [gender] CHAR(1) NOT NULL, 
  [civilstatus] VARCHAR(45), 
  [address] VARCHAR(255), 
  [barangayid] INT NOT NULL CONSTRAINT [fk_members_barangay] REFERENCES [barangay]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  [status] VARCHAR(45) NOT NULL DEFAULT 'active', 
  [created] DATETIME NOT NULL, 
  [created_by] VARCHAR(45) NOT NULL, 
  [modified] DATETIME, 
  [modified_by] VARCHAR(45), 
  CONSTRAINT [sqlite_autoindex_member_detail_1] PRIMARY KEY ([id], [sc_id]))      s                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         �
	)-;;osca-001irosinteacherroman catholic999filipinoBSBAcomputer hacking  2013-12-18 16:22:45.000jhoe2013-12-18 16:22:55.000jhoe
      �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		osca-001      3z�             �`�tableprovinceprovinceCREATE TABLE [province] (
  [id] INT NOT NULL, 
  [provincename] VARCHAR(255) NOT NULL, 
  [state] SMALLINT NOT NULL DEFAULT 1, 
  CONSTRAINT [sqlite_autoindex_province_1] PRIMARY KEY ([id]))/C indexsqlite_autoindex_province_1province�D�ktabletowntownCREATE TABLE [town] (
  [id] INT NOT NULL, 
  [townname] VARCHAR(255) NOT NULL, 
  [province_id] INT NOT NULL CONSTRAINT [fk_town_province] REFERENCES [province]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  [state] SMALLINT NOT NULL, 
  CONSTRAINT [sqlite_autoindex_town_1] PRIMARY KEY ([id]))'; indexsqlite_autoindex_town_1town�Z�tablebarangaybarangayCREATE TABLE [barangay] (
  [id] INT NOT NULL, 
  [barangayname] VARCHAR(255) NOT NULL, 
  [town_id] INT NOT NULL CONSTRAINT [fk_barangay_town] REFERENCES [town]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  [state] SMALLINT NOT NULL DEFAULT 1, 
  CONSTRAINT [sqlite_autoindex_barangay_1] PRIMARY KEY ([id]))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              �9cc�9tabletemp_table_27E74EF9F4E64890AD24B841846B1C72temp_table_27E74EF9F4E64890AD24B841846B1C72CREATE TABLE "temp_table_27E74EF9F4E64890AD24B841846B1C72" (
  [members_id] INT NOT NULL, 
  [members_sc_id] VARCHAR(45) NOT NULLv�	c indexsqlite_autoindex_temp_table_27E74EF9F4E64890AD24B841846B1C72_1temp_table_27E74EF9F4E64890AD24B841846B1C72�`�tableprovinceprovinceCREATE TABLE [province] (
  [id] INT NOT NULL, 
  [provincename] VARCHAR(255) NOT NULL, 
  [state] SMALLINT NOT NULL DEFAULT 1, 
  CONSTRAINT [sqlite_autoindex_province_1] PRIMARY KEY ([id]))/C indexsqlite_autoindex_province_1province�D�ktabletowntownCREATE TABLE [town] (
  [id] INT NOT NULL, 
  [townname] VARCHAR(255) NOT NULL, 
  [province_id] INT NOT NULL CONSTRAINT [fk_town_province] REFERENCES [province]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  [state] SMALLINT NOT NULL, 
  CONSTRAINT [sqlite_autoindex_town_1] PRIMARY KEY ([id]))    _  _ ���     /C indexsqlite_autoindex_province_1province   �n11�tablemember/C indexsqlite_autoindex_barangay_1barangay�m11�tablemember_informationmember_informationCREATE TABLE [member_information] (
  [members_id] INT NOT NULL, 
  [members_sc_id] VARCHAR(45) NOT NULL, 
  [birthplace] VARCHAR(255) NOT NULL, 
  [occupation] VARCHAR(45) NOT NULL, 
  [religion] VARCHAR(255) NOT NULL, 
  [phone] VARCHAR(12) NOT NULL, 
  [citizenship] VARCHAR(45) NOT NULL, 
  [education] VARCHAR(255) NOT NULL, 
  [skills] VARCHAR(255) NOT NULL, 
  [image] TEXT NOT NULL, 
  [sign] TEXT NOT NULL, 
  [created] DATETIME NOT NULL, 
  [created_by] VARCHAR(45) NOT NULL, 
  [modified] DATETIME, 
  [modified_by] VARCHAR(45), 
  CONSTRAINT [fk_member_information_members1] FOREIGN KEY([members_id], [members_sc_id]) REFERENCES [member_detail]([id], [sc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  CONSTRAINT [sqlite_autoindex_member_information_1] PRIMARY KEY ([members_id], [members_sc_id]))   � �                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        		Sorsogon
   � �                                        �Gcc�Utabletemp_�n11�tablemember_informationmember_informationCREATE TABLE [member_information] (
  [members_id] INT NOT NULL, 
  [members_sc_id] VARCHAR(45) NOT NULL, 
  [birthplace] VARCHAR(255) NOT NULL, 
  [occupation] VARCHAR(45) NOT NULL, 
  [religion] VARCHAR(255) NOT NULL, 
  [mobile] VARCHAR(12) NOT NULL, 
  [citizenship] VARCHAR(45) NOT NULL, 
  [education] VARCHAR(255) NOT NULL, 
  [skills] VARCHAR(255) NOT NULL, 
  [image] TEXT NOT NULL, 
  [sign] TEXT NOT NULL, 
  [created] DATETIME NOT NULL, 
  [created_by] VARCHAR(45) NOT NULL, 
  [modified] DATETIME, 
  [modified_by] VARCHAR(45), 
  CONSTRAINT [fk_member_information_members1] FOREIGN KEY([members_id], [members_sc_id]) REFERENCES [member_detail]([id], [sc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
  CONSTRAINT [sqlite_autoindex_member_information_1] PRIMARY KEY ([members_id], [members_sc_id]))CW1 indexsqlite_autoindex_member_information_1member_informat		   � �- G                                                      �m11�tablemember_informationmember_informationCREATE TABLE [member_information] (
  [members_id] INT NOT NULL, 
  [members_sc_id] VARCHAR(45) NOT NULL, 
  [birthplace] VARCHAR(255) NOT NULL, 
  [occupation] VARCHAR(45) NOT NULL, 
  [religion] VARCHAR(255) NOT NULL, 
  [phone] VARCHAR(12) NOT NULL, 
  [citizenship] VARCHAR(45) NOT NULL, 
  [education] VARCHAR(255) NOT NULL, 
  [skills] VARCHAR(25C W1 indexsqlite_autoindex_member_information_1member_information�P!�wviewvmembersvmembersCREATE VIEW [vmembers] AS 
SELECT a.*, b.[barangayname], c.[townname], d.[provincename], e.birthplace, e.[occupation], e.religion, e.phone, e.citizenship, e.[education], e.[skills], e.[image],e.sign
FROM member_detail AS a
INNER JOIN barangay AS b ON a.barangayid=b.id
INNER JOIN town AS c ON b.[town_id] =c.id
INNER JOIN province AS d ON c.[province_id] = d.id
INNER JOIN [member_information] AS e ON a.[sc_id] = e.[members_sc_id]