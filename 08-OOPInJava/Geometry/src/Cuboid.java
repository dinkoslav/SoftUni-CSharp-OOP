import java.util.ArrayList;

public class Cuboid extends SpaceShape{
    private double width;
    private double height;
    private double depth;

    public Cuboid(ArrayList<Vertex> vertices, double width, double height, double depth) {
        super(vertices);
        this.setWidth(width);
        this.setHeight(height);
        this.setVertex(vertices);
        this.setDepth(depth);
    }

    public void setWidth(double width) {
        if (width <= 0){
            throw new ArithmeticException("Width can not be zero or negative!");
        }
        this.width = width;
    }

    public void setDepth(double depth) {
        if (depth <= 0){
            throw new ArithmeticException("Depth can not be zero or negative!");
        }
        this.depth = depth;
    }

    public void setHeight(double height) {
        if (height <= 0){
            throw new ArithmeticException("Height can not be zero or negative!");
        }
        this.height = height;
    }

    public void setVertex(ArrayList<Vertex> vertexArrayList) {
        if (vertexArrayList.size() != 1){
            throw new IllegalArgumentException("Cuboid needs only 1 vertex!");
        }
    }

    @Override
    public double getArea() {
        return (2*this.width*this.height) +
                (2*this.width*this.depth) +
                (2*this.depth*this.height);
    }

    @Override
    public double getVolume() {
        return (this.width * this.height * this.depth);
    }
}
