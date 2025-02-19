pipeline {
    agent any
    environment {
        DOCKER_CREDENTIAL_ID = 'docker-access-token'
        DOCKER_IMAGE = 'hyeokjunyun/webapp'
    }
    stages {
        stage('Clone') {
            steps {
                git url: 'https://github.com/gyrwns12/webapp.git', branch: 'master'
            }
        }
        stage('Build') {
            steps {
                sh 'docker build -t $DOCKER_IMAGE:latest -f WebApp/Dockerfile WebApp/'  // WebApi ���ο��� ����
            }
        }
        stage('Push') {
            steps {
                withCredentials([usernamePassword(credentialsId: env.DOCKER_CREDENTIAL_ID, usernameVariable: 'DOCKER_USER', passwordVariable: 'DOCKER_PASS')]) {
                    sh 'docker login -u $DOCKER_USER -p $DOCKER_PASS'
                    sh 'docker push $DOCKER_IMAGE:latest'
                }
            }
        }
        stage('Deploy') {
            steps {
                script {
                    sh 'kubectl apply -f WebApp/webapp-deployment.yaml'  // WebApp ���ο��� ����
                    sh 'kubectl apply -f WebApp/webapp-service.yaml'
                }
            }
        }
    }
}