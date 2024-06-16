package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Favorites;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IFavoriteRepositories extends JpaRepository<Favorites,Long> {
}
