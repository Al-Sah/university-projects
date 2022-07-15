#include "mainwindow.h"
#include "gamedialog.h"
#include "ui_mainwindow.h"
#include "ui_fastGameWnd.h"
#include "ui_levelsWnd.h"

#include <fstream>
#include <QGraphicsScene>
#include <QGraphicsPixmapItem>
#include <QPixmap>

MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent){
    mainUi = new Ui::MainWindow();
    gc = new GraphsContainer;
    loadLevels();
    loadLvlAnsv();

    mainUi->setupUi(this);
    QPixmap imag = QPixmap("/home/al_sah/qt5projects/graphBasedGameqQT/images/pic.png");
    if(!imag.isNull()){
         mainUi->imageLabel->setPixmap(
         imag.scaled( mainUi->imageLabel->size(), Qt::KeepAspectRatio, Qt::SmoothTransformation) );
    }




    connect(mainUi->fastGameBtn, SIGNAL(clicked(bool)), this, SLOT(setFastGameUi()) );
    connect(mainUi->aboutBtn,    SIGNAL(clicked(bool)), this, SLOT(setAboutUi())    );
    connect(mainUi->educationBtn,SIGNAL(clicked(bool)), this, SLOT(setEducationUi()));
    connect(mainUi->levelsBtn,   SIGNAL(clicked(bool)), this, SLOT(setLevelsUi())   );

    //connect(mainUi->listWidget, SIGNAL(itemClicked(QListWidgetItem*)), this, SLOT(setBtnActive()));

    connect(mainUi->backBtn,   SIGNAL(clicked(bool)), this, SLOT(setMainUi()));
    connect(mainUi->backBtn_2, SIGNAL(clicked(bool)), this, SLOT(setMainUi()));
    connect(mainUi->backBtn_3, SIGNAL(clicked(bool)), this, SLOT(setMainUi()));
    connect(mainUi->backBtn_4, SIGNAL(clicked(bool)), this, SLOT(setMainUi()));

    connect(mainUi->easyBtn, SIGNAL(clicked(bool)), this, SLOT(generateEasyLevel()));
    connect(mainUi->normalBtn, SIGNAL(clicked(bool)), this, SLOT(generateNormalLevel()));
    connect(mainUi->hardBtn, SIGNAL(clicked(bool)), this, SLOT(generateHardLevel()));

    connect(mainUi->startGameBtn, SIGNAL(clicked(bool)), this, SLOT(runSelectedLvl()));

    connect(mainUi->listWidget, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(enableStartGameBtn()));


    mainUi->startGameBtn->setEnabled(false);

    mainUi->StackedWidget->setCurrentIndex(0);
}

MainWindow::~MainWindow(){
    delete mainUi;
}

void MainWindow::runGameDialog(int lvl){
    std::string asw;
    if(lvl > 100){
        asw = "";
    } else{
        asw = ansvers[lvl-1];
    }
    GameDialog *dmDlg = new GameDialog(0, lvl, gc, asw);
    dmDlg->setModal(true);
    dmDlg->show();
    dmDlg->exec();
}
void MainWindow::enableStartGameBtn(){
    mainUi->startGameBtn->setEnabled(true);
}

void MainWindow::runSelectedLvl(){
     QListWidgetItem *item = mainUi->listWidget->currentItem();
     QString itm = item->text();
     runGameDialog(itm.split(" ")[0].toInt());
}
void MainWindow::loadLevels(){
    //std::ifstream input("levels.txt");
    std::basic_ifstream<char> input;
      input.open("levels.txt");
      if (!input.is_open()) {
          throw "zzz";
      }
    int vertex, arches;
     while (!input.eof()){
        input >> vertex;
        input >> arches;
        Graph * graph = new weightedGraph(vertex);
        graph->setArces(arches);
        auto graph_matrix = (int (*)[vertex]) graph->getGraphPointer();
        for(int i = 0; i< vertex; i++){
            for(int j = 0; j < vertex; j++){
                input >> graph_matrix[j][i];
            }
        }
        graph->setArces(arches);
        gc->push_back(graph);
    }
}
void MainWindow::loadLvlAnsv() {
    std::basic_ifstream<char> input;
    std::string ansver;
      input.open("ansv.txt");
      if (!input.is_open()) {
          throw "zzz";
      }
       while (!input.eof()){
           input >> ansver;
           ansvers.push_back(ansver);
       }
}


void MainWindow::setMainUi(){
    mainUi->StackedWidget->setCurrentIndex(0);
}
void MainWindow::setFastGameUi(){
    mainUi->StackedWidget->setCurrentIndex(1);
}
void MainWindow::setLevelsUi(){
    mainUi->StackedWidget->setCurrentIndex(3);
}
void MainWindow::setEducationUi(){
    mainUi->StackedWidget->setCurrentIndex(2);
}
void MainWindow::setAboutUi(){
    mainUi->StackedWidget->setCurrentIndex(4);
}

void MainWindow::setBtnActive(QPushButton * btn){
    btn->setEnabled(true);
}

void MainWindow::generateEasyLevel(){
    runGameDialog(111);
}
void MainWindow::generateNormalLevel(){
    runGameDialog(112);
}
void MainWindow::generateHardLevel(){
    runGameDialog(113);
}



