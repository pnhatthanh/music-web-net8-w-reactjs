-- Bảng Vai trò
CREATE TABLE Roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) UNIQUE
);

-- Bảng Người dùng
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) UNIQUE,
    Email VARCHAR(100) UNIQUE,
    Password VARCHAR(255),
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);
CREATE TABLE Artists (
    ArtistID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT UNIQUE,
    ArtistName VARCHAR(100),
    Country VARCHAR(100),
    YearOfBirth INT,
    AudioFilePath VARCHAR(255),
    ImagePath VARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
CREATE TABLE Songs (
    SongID INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100),
    ArtistID INT,
    AlbumID INT,
    Genre VARCHAR(50),
    FilePath VARCHAR(255),
    FOREIGN KEY (ArtistID) REFERENCES Artists(ArtistID),
    FOREIGN KEY (AlbumID) REFERENCES Albums(AlbumID)
);
CREATE TABLE Albums (
    AlbumID INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100),
    ArtistID INT,
    ReleaseYear INT,
    CoverImagePath VARCHAR(255),
    FOREIGN KEY (ArtistID) REFERENCES Artists(ArtistID)
);

-- Bảng Danh sách phát
CREATE TABLE Playlists (
    PlaylistID INT AUTO_INCREMENT PRIMARY KEY,
    PlaylistName VARCHAR(100),
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Liên kết Bài hát - Danh sách phát
CREATE TABLE Song_Playlist (
    SongID INT,
    PlaylistID INT,
    PRIMARY KEY (SongID, PlaylistID),
    FOREIGN KEY (SongID) REFERENCES Songs(SongID),
    FOREIGN KEY (PlaylistID) REFERENCES Playlists(PlaylistID)
);

-- Bảng Lịch sử nghe nhạc
CREATE TABLE ListeningHistory (
    HistoryID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT,
    SongID INT,
    ListeningTime DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (SongID) REFERENCES Songs(SongID)
);

-- Bảng Tình trạng yêu thích
CREATE TABLE Favorites (
    FavoriteID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT,
    SongID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (SongID) REFERENCES Songs(SongID)
);

CREATE TABLE Categories (
    idCategory INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

ALTER TABLE Songs
ADD COLUMN CategoryID INT,
ADD COLUMN SongImagePath VARCHAR(255),
ADD CONSTRAINT FK_CategoryID FOREIGN KEY (CategoryID) REFERENCES Categories(idCategory);
