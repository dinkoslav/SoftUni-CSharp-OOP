import Interfaces.AreaMeasurable;
import Interfaces.VolumeMeasurable;

import java.util.ArrayList;

public abstract class SpaceShape extends Shape
        implements VolumeMeasurable, AreaMeasurable {

    public SpaceShape(ArrayList<Vertex> vertices) {
        super(vertices);
        this.setVertices3D(vertices);
    }

    public void setVertices3D(ArrayList<Vertex> vertices3D) {
        for (Vertex vertex : vertices3D) {
            if (Double.isNaN(vertex.getZ())) {
                throw new IllegalArgumentException("3D vertices must have Z!");
            }
        }
    }

    @Override
    public String toString() {
        return "Shape type : " + this.getClass().getName() +
                " \n" + super.toString() +
                this.getClass().getName() + " area : " + String.format("%.2f", this.getArea()) +
                "\n" + this.getClass().getName() + " volume : " + String.format("%.2f", this.getVolume()) + "\n";
    }
}
