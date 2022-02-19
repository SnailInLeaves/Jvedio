﻿
-- 5.0 前的数据库

-- 演员表
create table if not exists actress (
    id VARCHAR(50) PRIMARY KEY,
    name VARCHAR(50),
    birthday VARCHAR(10),
    age INT,
    height INT,
    cup VARCHAR(1),
    chest INT,
    waist INT,
    hipline INT,
    birthplace VARCHAR(50),
    hobby TEXT,
    sourceurl TEXT,
    source VARCHAR(10),
    imageurl TEXT
);

-- 影片表
create table if not exists movie (
    id VARCHAR(50) PRIMARY KEY,
    title TEXT,
    filesize DOUBLE DEFAULT 0,
    filepath TEXT,
    subsection TEXT,
    vediotype INT,
    scandate VARCHAR(30),
    releasedate VARCHAR(10) DEFAULT '1900-01-01',
    visits INT DEFAULT 0,
    
    director VARCHAR(50),
    genre TEXT,
    tag TEXT,
    actor TEXT,
    actorid TEXT,
    studio VARCHAR(50),
    rating FLOAT DEFAULT 0,

    chinesetitle TEXT,
    favorites INT DEFAULT 0,

    label TEXT,
    plot TEXT,
    outline TEXT,
    year INT DEFAULT 1900,
    runtime INT DEFAULT 0,
    country VARCHAR(50),
    countrycode INT DEFAULT 0,
    otherinfo TEXT,
    sourceurl TEXT,
    source VARCHAR(10),
    actressimageurl TEXT,
    smallimageurl TEXT,
    bigimageurl TEXT,
    extraimageurl TEXT
);

-- 翻译表
create table if not exists youdao (
    id VARCHAR(50) PRIMARY KEY,
    title TEXT,
    translate_title TEXT,
    plot TEXT,
    translate_plot TEXT
)

-- 磁力表
create table if not exists magnets (
    link VARCHAR(60) PRIMARY KEY,
    id VARCHAR(50),
    title TEXT,
    size DOUBLE DEFAULT 0,
    releasedate VARCHAR(10) DEFAULT '1900-01-01',
    tag TEXT
)


-- javdb 照应表
create table if not exists javdb (
    id VARCHAR(50) PRIMARY KEY,
    code VARCHAR(50)
);


-- library 照应表
create table if not exists library (
    id VARCHAR(50) PRIMARY KEY,
    code VARCHAR(50)
);