import java.util.ArrayList;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(ArrayList<Vertex> vertices2D, double width, double height) {
        super(vertices2D);
        this.setVertex(vertices2D);
        this.setWidth(width);
        this.setHeight(height);
    }

    public void setVertex(ArrayList<Vertex> vertexArrayList) {
        if (vertexArrayList.size() != 1){
            throw new IllegalArgumentException("Rectangle needs only 1 vertex!");
        }
    }

    public void setWidth(double width) {
        if (width <= 0){
            throw new ArithmeticException("Width can not be zero or negative!");
        }
        this.width = width;
    }

    public void setHeight(double height) {
        if (height <= 0){
            throw new ArithmeticException("Height can not be zero or negative!");
        }
        this.height = height;
    }

    @Override
    public double getArea() {
        return this.width * this.height;
    }

    @Override
    public double getPerimeter() {
        return this.width + this.width + this.height + this.height;
    }
}
