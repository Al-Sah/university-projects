#include "gamedialog.h"
#include "ui_gamedialog.h"
#include "graphwidget.h"

#include <QCheckBox>
#include <QGridLayout>
#include <fstream>
#include <QMessageBox>

GameDialog::GameDialog(QWidget *parent, int lvl, GraphsContainer * gc, std::string ansv) : QDialog(parent), ui(new Ui::GameDialog){
    this->grc = gc;
    this->ansv = ansv;
    ui->setupUi(this);
    generateGraph(lvl);

    GraphWidget *widget = new GraphWidget(0, graph);

    ui->textBrowser->setText(QString::fromStdString(graph->getVertexList()));

    ui->gridLayout_2->addWidget(widget);
    connect(ui->exitBtn,SIGNAL(clicked(bool)), this, SLOT(close()));
    connect(ui->checkBtn,SIGNAL(clicked(bool)), this, SLOT(check()));

}

GameDialog::~GameDialog()
{
    delete ui;
}

void GameDialog::check(){
    QMessageBox msgBox;
    QString resText = ui->lineEdit->text();
    bool ok = false;
    if(resText == QString::fromStdString(this->ansv)){ok = true;}
    if(ok){
        msgBox.setText("Congratulations !!!!!");

    }else{
        msgBox.setText("Loser !!!!!");
        msgBox.setInformativeText("Your answer is: [" +resText + "]\nCorrct answer is: [" + QString::fromStdString(this->ansv) + "]\n");
    }
    msgBox.setStandardButtons(QMessageBox::Ok);
    msgBox.exec();
}


void GameDialog::generateGraph(int lvl){
    switch (lvl) {
    case 111:
         graph = new weightedGraph(10);
         grc->addArchsToGraph(&graph);
         break;
    case 112:
         graph = new weightedGraph(25);
         grc->addArchsToGraph(&graph);
         break;
    case 113:
         graph = new weightedGraph(40);
         grc->addArchsToGraph(&graph);
        break;
    default:
         graph = (*grc)[int(lvl-1)];
        break;
    }
}
