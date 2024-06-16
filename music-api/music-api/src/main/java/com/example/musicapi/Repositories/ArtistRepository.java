package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Artists;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IArtistRepositories extends JpaRepository<Artists,Long> {
}
