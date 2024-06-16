package com.example.musicapi.Repositories;

import com.example.musicapi.Models.ListeningHistories;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IListeningHistoryRepositories extends JpaRepository<ListeningHistories,Long> {
}
