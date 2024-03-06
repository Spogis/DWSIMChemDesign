
# Easy Curve Fit - App for Curve Fitting

## Introduction

Curve fitting is an essential tool in chemical engineering, enabling professionals and researchers to model complex processes and phenomena through mathematical equations. This app was developed to simplify the application of different curve fitting models, such as Linear, Exponential, First Order Model, Generalized Logistic Function, Granulometric Distribution, and Nagata Equation, facilitating precise and optimized analyses in various chemical engineering contexts.

## Importance of Curve Fitting in Chemical Engineering

Curve fitting is crucial in chemical engineering for process modeling, reaction optimization, quality control, and the development of new materials and products. The ability to predict behaviors and deeply understand the relationships between variables allows for innovations and operational efficiencies, highlighting the importance of tools like this app for professionals in the field.

## Examples of Curve Fitting Models

[![Watch the video](https://img.youtube.com/vi/qxRbjU4bems/0.jpg)](https://youtu.be/qxRbjU4bems)


### Linear Model

Ideal for direct relationships between variables, offering a simple solution for initial trend analyses.

### Exponential Model

Applicable in growth or decay processes that follow a constant rate proportional to the current size of the system.

### First Order Model

Often used in system dynamics where the rate of change is proportional to the current state.

### Generalized Logistic Function

Used to model population growth, saturation processes, and other phenomena that approach a maximum limit.

### Granulometric Distribution

Essential for characterizing the size distribution of particles in mixtures, commonly used in soil, sediment, and powdered materials analyses.

### Nagata Equation

Applies to fluid dynamics and the study of flows, especially useful in chemical engineering for modeling behaviors of mixtures and reactions.

## Model Customization

The unique feature of this app is the ability to create and adjust your own custom models. You are not limited to predefined models; our intuitive interface allows you to define any type of equation to fit your specific data, offering unprecedented flexibility in your analyses.

---

## Data Prep - Ramer-Douglas-Peucker

The Ramer-Douglas-Peucker algorithm is a method used in computer graphics and GIS to simplify curves or polylines by reducing points. It was independently developed by Urs Ramer in 1972 and by David Douglas and Thomas Peucker in 1973. The algorithm works by approximating a curve with fewer points, maintaining the shape's essential features within a specified tolerance.

The process starts by connecting the first and last points of the curve with a line, identifying the farthest point from this line, and keeping it if its distance exceeds the tolerance. This point divides the curve into two segments, and the algorithm recursively simplifies each segment. This iterative approach significantly reduces data complexity in GIS applications, enhancing storage, processing, and display efficiencies without compromising the geographical features' visual integrity.

The Ramer-Douglas-Peucker algorithm exemplifies how data reduction can be achieved without losing significant geometric detail, making it invaluable in digital mapping and various applications requiring efficient rendering of complex shapes.

[![Watch the video](https://img.youtube.com/vi/u1ZMzY5kwiA/0.jpg)](https://youtu.be/u1ZMzY5kwiA)

---

## Installation

To install the necessary dependencies, you need to have Python installed on your system. If you don't have Python, you can download it [here](https://www.python.org/downloads/). After installing Python, follow the steps below:

1. **Clone the Repository**

   First, clone the Easy Curve Fit repository to your local machine.

2. **Install Dependencies**

   Inside the project directory, there is a file called `requirements.txt` that contains all the necessary libraries. To install them, execute the following command: **pip install -r requirements.txt**

   This will install all the necessary dependencies to run Easy Curve Fit.

## Execution

To run the application, follow these steps:

* Navigate to the project directory where `main.py` is located.

* Execute the `main.py` file using Python: **python main.py**

* After running the command, Dash will start the local server and you can access the application through your browser. Normally, the URL will be something like `http://127.0.0.1:8050/`.

## Example Datasets

* In the [Datasets](https://github.com/Spogis/EasyCurveFit/tree/master/Datasets) directory, you will find example datasets that can assist you.

## Support

If you encounter any problems or have any questions, do not hesitate to open an issue in the GitHub repository or contact us directly.

## Contact: https://linktr.ee/CascaGrossaSuprema

---

We hope you enjoy using Easy Curve Fit!
