package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Albums;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IAlbumRepositories extends JpaRepository<Albums,Long> {

}
