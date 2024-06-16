package com.example.musicapi.Repositories;

import com.example.musicapi.Models.PlayLists;
import org.springframework.data.jpa.repository.JpaRepository;

public interface  IPlayListRepositories extends JpaRepository<PlayLists,Long> {
}
