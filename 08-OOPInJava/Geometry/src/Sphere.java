import java.util.ArrayList;

public class Sphere extends SpaceShape{
    private double radius;

    public Sphere(ArrayList<Vertex> vertices, double radius) {
        super(vertices);
        this.setVertex(vertices);
        this.setRadius(radius);
    }

    public void setRadius(double radius) {
        if (radius <= 0){
            throw new ArithmeticException("Radius can not be zero or negative!");
        }
        this.radius = radius;
    }

    public void setVertex(ArrayList<Vertex> vertexArrayList) {
        if (vertexArrayList.size() != 1){
            throw new IllegalArgumentException("Sphere needs only 1 vertex!");
        }
    }

    @Override
    public double getArea() {
        return (4 * Math.PI * Math.pow(this.radius, 2));
    }

    @Override
    public double getVolume() {
        return ((4* Math.PI*Math.pow(this.radius, 3))/3);
    }
}
