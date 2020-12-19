#ifndef MAINWINDOW_H
#define MAINWINDOW_H


#include "graphs.h"
#include <QMainWindow>
#include <QPushButton>
#include <vector>

QT_BEGIN_NAMESPACE
namespace Ui {
    class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    void runGameDialog(int lvl);
    ~MainWindow();

private:
    std::vector<std::string> ansvers;
    Ui::MainWindow *mainUi;
    GraphsContainer * gc;
    QImage myImage;

    void loadLevels();
    void loadLvlAnsv();

private slots:
    void setFastGameUi();
    void setMainUi();
    void setAboutUi();
    void setEducationUi();
    void setLevelsUi();
    void setBtnActive(QPushButton * btn);

    void generateEasyLevel();
    void generateNormalLevel();
    void generateHardLevel();

    void runSelectedLvl();
    void enableStartGameBtn();

};


#endif // MAINWINDOW_H
