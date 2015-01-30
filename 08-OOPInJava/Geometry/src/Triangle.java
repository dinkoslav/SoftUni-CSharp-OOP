import java.util.ArrayList;

public class Triangle extends PlaneShape {

    ArrayList<Vertex> triangle = new ArrayList<Vertex>();

    public Triangle(ArrayList<Vertex> triangle) {
        super(triangle);
        this.setTriangle(triangle);
    }

    public void setTriangle(ArrayList<Vertex> triangle) {
        if (triangle.size() != 3){
            throw new IllegalArgumentException("Triangle must have 3 vertices!");
        }
        this.triangle = triangle;
    }

    @Override
    public double getArea() {
        double[] sides = getSides(this.triangle);
        double p = this.getPerimeter() / 2;
        double area = Math.sqrt(p*(p-sides[0])*(p-sides[1])*(p-sides[2]));
        return area;
    }

    @Override
    public double getPerimeter() {
        double[] sides = getSides(this.triangle);
        double perimeter = sides[0] + sides[1] + sides[2];
        return perimeter;
    }

    private double[] getSides(ArrayList<Vertex> triangle){
        double[] sides = new double[3];
        sides[0] = this.calculateDistanceBetweenTwoPoints(triangle.get(0), triangle.get(1));
        sides[1] = this.calculateDistanceBetweenTwoPoints(triangle.get(0), triangle.get(2));
        sides[2] = this.calculateDistanceBetweenTwoPoints(triangle.get(2), triangle.get(1));
        return sides;
    }
}
