package Shapes;
import javax.swing.*;
import java.awt.*;

public class Shape extends JComponent {

	public void draw()
	{
		GeometricShape shape = new GeometricShape(width, height);
		rect = new Rectangle(xUpperLeftCorner, yUpperLeftCorner, shape.getXLowerRightCorner(), shape.getYLowerRightCorner());
		this.repaint();
	}
	
	public void paint(Graphics g) {
		super.paint(g);
		Graphics2D g2 = (Graphics2D)g;
		g2.draw(rect);
	}	
	
    private int xUpperLeftCorner = 0;
	private int yUpperLeftCorner = 0;
	private int width = 200;
	private int height = 100;
	private Rectangle rect;
}
