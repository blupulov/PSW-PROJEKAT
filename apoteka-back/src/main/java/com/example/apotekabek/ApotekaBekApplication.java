package com.example.apotekabek;

import com.example.apotekabek.model.Drug;
import com.example.apotekabek.repository.DrugRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableScheduling;

import java.util.ArrayList;
import java.util.List;

@EnableScheduling
@SpringBootApplication
public class ApotekaBekApplication implements CommandLineRunner {
	@Autowired
	private DrugRepository drugRepository;

	public static void main(String[] args) {
		SpringApplication.run(ApotekaBekApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Drug brfen = new Drug("Brufen", 100);
		Drug panadol = new Drug("Panadol", 100);
		Drug diklofenak = new Drug("Diklofenak", 100);
		Drug coldrex = new Drug("Coldrex", 100);

		drugRepository.save(brfen);
		drugRepository.save(panadol);
		drugRepository.save(diklofenak);
		drugRepository.save(coldrex);
	}
}
