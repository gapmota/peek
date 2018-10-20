package aplicacao;


import java.util.Scanner;

import controller.*;
import model.MAC;
import oshi.SystemInfo;

public class App {
	public static void main(String[] args) {

		ComputadorController cc = new ComputadorController();
		System.out.println(cc.cadastroInicial());
		
	}
}
