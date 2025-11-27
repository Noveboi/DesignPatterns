package Shapes;
import javax.swing.*;

public class Main {
	public static void main(String[] args) {
		
		Shape myShape = new Shape();
		
		JFrame f = new JFrame();
		f.setSize(600, 600);
		f.setContentPane(myShape);
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		myShape.draw();					        //APPLICATION 1
		f.setVisible(true);
		
												//APPLICATION 2

		GeometricShape myShape2 = new GeometricShape(200, 100);
		System.out.println("Lower Right Corner. X: " + myShape2.getXLowerRightCorner()
		                                    + " Y: " + myShape2.getYLowerRightCorner());
		                             
	}	
}
