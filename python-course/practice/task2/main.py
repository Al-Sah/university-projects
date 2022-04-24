from buttonsFrames import *
from inputFrames import *


class App(tk.Tk):

    def __init__(self):
        super().__init__()
        self.title('CV generator')
        self.geometry('800x600')
        self.resizable(False, False)

        self.columnconfigure(0, weight=1)
        self.rowconfigure(0, weight=6)
        self.rowconfigure(1, weight=1)

        self.buttons = {0: StartButtonsFrame(self), 1: NextPrevButtonsFrame(self), 2: FinishButtonsFrame(self)}
        self.currentButtonsFrameId = 0
        self.change_frame(self.currentButtonsFrameId)

        self.inputs = {0: WelcomeFrame(self)}
        self.currentInputFrameId = 0

    def handleFrameBtnClick(self, val):
        if val == "Next" or val == "Start":
            self.change_frame(self.currentButtonsFrameId + 1)
        if val == "Previous":
            self.change_frame(self.currentButtonsFrameId - 1)

    def change_frame(self, frameid):
        self.currentButtonsFrameId = frameid
        self.buttons[frameid].tkraise()


if __name__ == "__main__":
    app = App()
    app.mainloop()
