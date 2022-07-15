#ifndef GAMEDIALOG_H
#define GAMEDIALOG_H

#include "graphs.h"
#include <QDialog>

namespace Ui {
class GameDialog;
}

class GameDialog : public QDialog
{
    Q_OBJECT

public:
    explicit GameDialog(QWidget *parent = nullptr, int lvl = 1, GraphsContainer * gc = nullptr,  std::string ansv = "");
    void generateGraph(int lvl);
    ~GameDialog();

private:

    std::string ansv;
    Graph * graph;
    GraphsContainer * grc;
    Ui::GameDialog *ui;

private slots:
    void check();
};

#endif // GAMEDIALOG_H
