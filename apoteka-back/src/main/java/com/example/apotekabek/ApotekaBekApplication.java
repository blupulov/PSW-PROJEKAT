package com.example.apotekabek;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableScheduling;

@EnableScheduling
@SpringBootApplication
public class ApotekaBekApplication {

	public static void main(String[] args) {
		SpringApplication.run(ApotekaBekApplication.class, args);
	}

}
