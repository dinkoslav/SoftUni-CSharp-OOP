import Interfaces.AreaMeasurable;
import Interfaces.PerimeterMeasurable;

import java.util.ArrayList;

public abstract class PlaneShape extends Shape
        implements PerimeterMeasurable, AreaMeasurable {

    public PlaneShape(ArrayList<Vertex> vertices2D) {
        super(vertices2D);
        this.setVertices2D(vertices2D);

    }

    public void setVertices2D(ArrayList<Vertex> vertices2D) {
        for (Vertex vertex : vertices2D) {
            if (!Double.isNaN(vertex.getZ())) {
                throw new IllegalArgumentException("2D vertices dont have Z!");
            }
        }
    }

    public double calculateDistanceBetweenTwoPoints(Vertex v1, Vertex v2){
        double distance = Math.sqrt(
                Math.pow((v1.getX() - v2.getX()), 2) +
                Math.pow((v1.getY() - v2.getY()), 2)
        );
        return distance;
    }

    @Override
    public String toString() {
        return "Shape type : " + this.getClass().getName() +
                " \n" + super.toString() +
                this.getClass().getName() + " area : " + String.format("%.2f", this.getArea()) +
                "\n" + this.getClass().getName() + " perimeter : " + String.format("%.2f", this.getPerimeter()) + "\n";
    }
}
