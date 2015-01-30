import Interfaces.VolumeMeasurable;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class GeometryTest {
    public static void main(String[] args){

        //Triangle
        ArrayList<Vertex> three = new ArrayList<Vertex>();
        three.add(new Vertex(10,4));
        three.add(new Vertex(30,4));
        three.add(new Vertex(60,1));
        Triangle triangle = new Triangle(three);

        //Rectangle
        ArrayList<Vertex> rect = new ArrayList<Vertex>();
        rect.add(new Vertex(1,4));
        Rectangle rectangle = new Rectangle(rect, 5, 10);

        //Circle
        ArrayList<Vertex> circ = new ArrayList<Vertex>();
        circ.add(new Vertex(1,4));
        Circle circle = new Circle(circ, 5);

        //Square Pyramid
        ArrayList<Vertex> sqp = new ArrayList<Vertex>();
        sqp.add(new Vertex(1,4,5));
        SquarePyramid squarePyramid = new SquarePyramid(sqp, 7, 10);

        //Cuboid
        ArrayList<Vertex> cub = new ArrayList<Vertex>();
        cub.add(new Vertex(1,4,5));
        Cuboid cuboid = new Cuboid(cub, 5, 5, 5);

        //Sphere
        ArrayList<Vertex> sph = new ArrayList<Vertex>();
        sph.add(new Vertex(1,4,5));
        Sphere sphere = new Sphere(sph, 1);

        Shape[] shapes = new Shape[]{
                triangle,
                rectangle,
                circle,
                squarePyramid,
                cuboid,
                sphere
        };

//        for (Shape shape : shapes) {
//            System.out.println(shape);
//        }

        // Volume filter
        List<Shape> spaceShapes = Arrays.asList(shapes).stream()
                .filter(s -> s instanceof VolumeMeasurable)
                .filter(v -> ((VolumeMeasurable) v).getVolume() > 40)
                .collect(Collectors.toList());

//        for (Shape spaceShape : spaceShapes) {
//            System.out.println(spaceShape);
//        }

        //Perimeter filter
        Comparator<Shape> perimeterComparator =
                (Shape s1, Shape s2) -> Double.compare(
                        ((PlaneShape) s1).getPerimeter(),
                        ((PlaneShape) s2).getPerimeter());

        List<Shape> planeShapes = Arrays.asList(shapes).stream()
                .filter(s -> s instanceof PlaneShape)
                .sorted(perimeterComparator)
                .collect(Collectors.toList());

        for (Shape planeShape : planeShapes) {
            System.out.println(planeShape);
        }
    }
}
