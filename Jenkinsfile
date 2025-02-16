pipeline {
    agent any
    environment {
        IMAGE_NAME = "webapi"
    }
    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/gyrwns12/WebApp.git'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build -c Release'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
        stage('Deploy to Kubernetes') {
            steps {
                sh 'kubectl apply -f k8s-master/webapp-deployment.yaml'
            }
        }
    }
}