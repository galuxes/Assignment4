# Starting Project

Start your project by creating a **private** template from this
repository: <https://github.com/CC-GPR-350/a4>. Remember to:

1.  Make your repository **private**
2.  Add me as a collaborator
3.  Set your `UNITY_EMAIL`, `UNITY_PASSWORD`, and `UNITY_SERIAL` repository
    secrets


# Goal

Enhance the Shooting Game by adding collision detection between
spheres and other spheres, and between spheres and planes.


# Rules

1.  When spheres and planes are placed in the test scene, they are
    simulated accurately upon colliding with one another.
2.  Note that **there is no specific player input required for this assignment.**


# Game Functionality Enhancements

1.  Collisions occur correctly between all spheres and planes in a scene.


# Game Code Enhancements


## Adding Sphere-Sphere Collision Detection

1.  In the `CollisionDetection` class, implement the provided
    `GetNormalAndPenetration` functions to calculate the normal and
    penetration of any two spheres. The "NormalCalculation" and
    "PenetrationCalculation" tests will pass when this is correct.
2.  In the `CollisionDetection` class, implement the provided
    `ApplyCollisionResolution` function to update the position of two
    colliding spheres. The "DisplacementTestIgnoringMass" test will
    pass when this is correct.
3.  Augment `ApplyCollisionResolution` to update the velocity of two
    colliding spheres. The "VelocityTestIgnoringMass" test will pass
    when this is correct.
4.  Augment `ApplyCollisionResolution` to account for the different
    masses of the two colliding sphers. The "Displacement" and
    "Velocity" tests will pass when this is correct.


## Adding Sphere-Plane Collision Detection

1.  Implement the `Normal` and `Offset` functions in the
    `PlaneCollider` class.
2.  Repeat the steps for adding Sphere-Sphere collision detection,
    targeting the functions above that accept a sphere and a plane as
    their arguments. The Plane tests will pass when this is correct.


## Making collisions work in the scene.

1.  In the `CollisionManager`, add logic to the `FixedUpdate` function
    that will call `ApplyCollisionResolution` on every pair of spheres
    and every sphere-plane pair. The Scene Tests will pass when this is
    correct.


# Grading

Grades will be based on the above criteria, which will be assessed
automatically using the automated tests provided with the project files.
