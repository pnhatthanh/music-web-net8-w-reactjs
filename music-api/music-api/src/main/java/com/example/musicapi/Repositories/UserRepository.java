package com.example.musicapi.Repositories;

import com.example.musicapi.Models.Users;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUserRepositories extends JpaRepository<Users,Long> {
}
