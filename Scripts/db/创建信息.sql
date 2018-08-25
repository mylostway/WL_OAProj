-- 创建databases
CREATE DATABASE IF NOT EXISTS wldb DEFAULT CHARSET utf8 COLLATE utf8_general_ci;

show variables like 'character%';

alter database wldb default character set 'utf8';

-- 数据库存放数据的编码为utf8
SET character_set_database='utf8';
-- 连接的时候为gbk（中文输入兼容）
SET character_set_connection='gbk';
-- 客户端输入编码为gbk（如果为utf8，测试的时候会报错ERROR 1366 (HY000): Incorrect string value:……）
SET character_set_client='gbk';
-- 
SET character_set_results='gbk';

SET character_set_server='gbk';

SHOW FULL COLUMNS FROM t_goodsInfo;
SHOW FULL COLUMNS FROM t_wharfInfo;

alter table t_goodsInfo convert to character set utf8 collate utf8_general_ci;
alter table t_wharfInfo convert to character set utf8 collate utf8_general_ci;


-- 审计信息表，待考虑是否启用
create table wldb.t_auditInfo
(
	Fid int primary key auto_increment comment '数据唯一ID',
	
	FrefTableName varchar(50) not null comment '引用数据表名称',
	FrefFieldId int not null comment '引用数据表对应字段ID',
	FinputTime datetime not null comment '录入时间',
	FinputUser varchar(50) not null comment '录入人',
	FlastModifyTime datetime not null comment '最后一次修改时间',
	FlastModifyUser varchar(50) not null comment '最后一次修改人',
	
	-- 唯一约束到FrefTableName和FrefFieldId
	CONSTRAINT cr_ftn_ffid unique(FrefTableName,FrefFieldId)
)ENGINE=Innodb default charset=utf8;










-- 示例功能，创建司机信息表
create table wldb.t_driverInfo
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',
			
	Fname varchar(30) not null comment '司机姓名',
	Fphone1 varchar(15) not null comment '司机手机号码',
	Fphone2 varchar(15) not null default '' comment '司机备用手机号码',
	Fphone3 varchar(15) not null default '' comment '司机备用手机号码',
	FcertID varchar(20) not null default '' comment '司机证件号码',
	FDriverNo varchar(20) not null comment '驾驶证编号',
	FworkState tinyint not null default 0 comment '是否在职 0 - 否 1 - 是，其他待添加，默认0'
)ENGINE=Innodb default charset=utf8;

select * from wldb.t_driverInfo;


-- 示例功能2，创建货名维护表
create table wldb.t_goodsInfo
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',
			
	Fchn_Name varchar(50) not null comment '货物名称名（中文）',
	Feng_Name varchar(30) not null default '' comment '货物名称名（英文）',
	Fmark varchar(15) not null comment '助记码',
	FisCheckWeight tinyint not null default 0 comment '标志-需核实重量',
	Fusable tinyint not null default 0 comment '标志-可用'
)ENGINE=Innodb default charset=utf8;

select * from wldb.t_goodsInfo;

insert into t_goodsInfo(Fchn_Name,Fmark) values('测试商品','CSSP');


-- 示例功能3，创建港口码头表
create table wldb.t_wharfInfo
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',
			
	FPosition varchar(60) not null comment '位置，这是一个不定层级列表，目前使用;间隔',
	Falias varchar(30) not null default '' comment '别名',
	Fmark varchar(15) not null default '' comment '助记码',	
	Fop tinyint not null default 0 comment '操作，目前没值',
	
	FinputUser varchar(30) not null default 0 comment '录入人',
	FinputTime datetime not null comment '录入时间',
	FlastModifyUser varchar(30) comment '最后一次修改人',
	FlastModifyTime datetime comment '最后一次修改时间'
)ENGINE=Innodb default charset=utf8;

select * from wldb.t_wharfInfo;




-- 示例功能4，创建航线表
create table wldb.t_airway
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',
			
	Fchn_Name varchar(50) not null comment '航线名称名（中文）',
	Feng_Name varchar(30) not null default '' comment '航线名称名（英文）',
	Fremark varchar(60) not null default '' comment '备注',
	Fusable tinyint not null default 0 comment '标志-是否可用',
	FlastModifyTime datetime not null comment '最后修改时间'
)ENGINE=Innodb default charset=utf8;

select * from wldb.t_airway;












delete from wldb.t_driverInfo;
delete from wldb.t_wharfInfo;
delete from wldb.t_goodsInfo;











-- 用户自定义数据表
create table wldb.t_userDefineTable
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常',
	
	-- FTableID int not null unique comment '数据表ID',
	FName varchar(50) not null comment '数据表显示名称',
	FTableRefName varchar(50) not null comment '数据表引用名称',
	FMemo varchar(200) comment '备注',
	
)ENGINE=Innodb default charset=utf8;

-- 用户自定义数据表的数据含义
create table wldb.t_userDefineField
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常',
	
	FTableID int not null comment '字段所属的数据表ID',	
	FName varchar(50) not null comment '字段名称',
	FFieldType varchar(10) not null comment '字段类型，涉及到类型检测 - num数字,str字符串,enum - 枚举（字符串）',
	FFieldRefName varchar(30) not null comment '字段引用名称，关联到t_universalTable定义',	
	FMemo varchar(200) comment '字段备注',
	
)ENGINE=Innodb default charset=utf8;

select * from wldb.t_userDefineData;


-- 通用信息表，定义N个字段供用户使用，由信息映射表去涉及字段读写
create table wldb.t_universalTable
{
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常', 
	
	Fint1 int,
	Fint2 int,
	Fint3 int,
	Fint4 int,
	Fint5 int,
	Fint6 int,
	
	Fvarchar1 varchar(50),
	Fvarchar2 varchar(50),
	Fvarchar3 varchar(50),
	Fvarchar4 varchar(50),
	Fvarchar5 varchar(50),
	Fvarchar6 varchar(50),
	
	-- 比 256 大
	FmidVarchar1 varchar(260),
	FmidVarchar2 varchar(260),
	FmidVarchar3 varchar(260),
	
	-- 比1024 大
	FbigVarchar1 varchar(1030),
	FbigVarchar2 varchar(1030),
	FbigVarchar3 varchar(1030)
}ENGINE=Innodb default charset=utf8;



-- 用户定义的枚举信息配置
create table wldb.t_userEnmuInfo
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',
	FinputTime datetime not null comment '录入时间',
	FinputUser varchar(50) not null comment '录入人',
	FlastModifyTime datetime not null comment '最后一次修改时间',
	FlastModifyUser varchar(50) not null comment '最后一次修改人',
	
	FEnumId int not null comment unique '枚举ID',
	FName varchar(50) not null comment '枚举名称',
	FEnumType varchar(10) not null comment '字段类型，涉及到类型检测 - num数字,str字符串,enum - 枚举（字符串）',
	FFieldRefName varchar(30) not null comment '字段引用名称，关联到t_universalTable定义',
	FTableRefName varchar(50) not null comment '该数据映射过去的数据表',
	FMemo varchar(200) comment '枚举备注',
	
)ENGINE=Innodb default charset=utf8;


-- 用户定义的枚举的值
create table wldb.t_userEnmuVal
(
	Fid int primary key auto_increment comment '数据唯一ID',
	Fstate tinyint not null default 0 comment '数据状态 0 - 正常,1 - 软删除等异常状态',

	FEnumId int not null comment '枚举ID',
	FVal varchar(100) not null comment '枚举值'
	
)ENGINE=Innodb default charset=utf8;






