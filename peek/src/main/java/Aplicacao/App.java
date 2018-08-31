package Aplicacao;

import java.io.Console;

public class App {
	public static void main(String[] args) {
		
		
		new Thread(new Runnable() {
			
			public void run() {
				// TODO Auto-generated method stub
				
				while(true) {
					try {
					
						Computador c = new Computador();
						
						System.out.println(c.getRede().getVelocidade(0));						
						
						Thread.sleep(1000);
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				}
								
			}
		}).start();		
	}
}
