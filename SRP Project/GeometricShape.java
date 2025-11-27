public class GeometricShape {
    private int width;
    private int height;

    public GeometricShape(int width, int height) {
        this.width = width;
        this.height = height;
    }

    public int getXLowerRightCorner() {
		return width;
	}
	
	public int getYLowerRightCorner() {
		return height;
	}
}