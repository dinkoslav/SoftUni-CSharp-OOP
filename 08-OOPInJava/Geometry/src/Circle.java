import java.util.ArrayList;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(ArrayList<Vertex> vertices2D, double radius) {
        super(vertices2D);
        this.setVertex(vertices2D);
        this.setRadius(radius);
    }

    public void setVertex(ArrayList<Vertex> vertexArrayList) {
        if (vertexArrayList.size() != 1){
            throw new IllegalArgumentException("Circle needs only 1 vertex!");
        }
    }

    public void setRadius(double radius) {
        if (radius <= 0){
            throw new ArithmeticException("Radius can not be zero or negative!");
        }
        this.radius = radius;
    }

    @Override
    public double getArea() {
        return Math.PI * this.radius * this.radius;
    }

    @Override
    public double getPerimeter() {
        return 2 * Math.PI * this.radius;
    }
}
