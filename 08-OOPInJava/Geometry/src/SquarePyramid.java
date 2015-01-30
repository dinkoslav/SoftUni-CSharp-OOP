import java.util.ArrayList;

public class SquarePyramid extends SpaceShape{
    private double width;
    private double height;

    public SquarePyramid(ArrayList<Vertex> vertices, double width, double height) {
        super(vertices);
        this.setWidth(width);
        this.setHeight(height);
        this.setVertex(vertices);
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

    public void setVertex(ArrayList<Vertex> vertexArrayList) {
        if (vertexArrayList.size() != 1){
            throw new IllegalArgumentException("Square Pyramid needs only 1 vertex!");
        }
    }

    @Override
    public double getArea() {
        double s = Math.sqrt(
                Math.pow(this.height, 2) +
                Math.pow((this.width/2), 2));
        return ((2*this.width*s) + (this.width*this.width));
    }

    @Override
    public double getVolume() {
        return (this.width * this.width * this.height)/3;
    }
}
