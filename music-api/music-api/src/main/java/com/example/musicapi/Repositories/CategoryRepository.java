package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Categories;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ICategoryRepositories extends JpaRepository<Categories,Long> {
}
