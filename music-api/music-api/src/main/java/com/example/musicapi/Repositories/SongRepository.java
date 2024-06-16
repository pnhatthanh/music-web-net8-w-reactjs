package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Songs;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ISongRepositories extends JpaRepository<Songs,Long> {
}
