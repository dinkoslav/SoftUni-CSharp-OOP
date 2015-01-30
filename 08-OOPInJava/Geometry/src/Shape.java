import java.util.ArrayList;

public abstract class Shape {
    ArrayList<Vertex> vertices = new ArrayList<Vertex>();

    public Shape(ArrayList<Vertex> vertices) {
        this.setVertices(vertices);
    }

    public ArrayList<Vertex> getVertices() {
        return vertices;
    }

    public void setVertices(ArrayList<Vertex> vertices) {
        this.vertices = vertices;
    }

    @Override
    public String toString() {
        String result = "Vertices: \n";
        for (Vertex vertix : this.vertices) {
            result += "{X = " + vertix.getX() +
                    ", Y = " + vertix.getY();
            if (!Double.isNaN(vertix.getZ())){
                result +=", Z = " + vertix.getZ();
            }
            result +="}\n";
        }
        return result;
    }
}
