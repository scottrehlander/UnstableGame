#ifndef __UnstableFrameListener_h_
#define __UnstableFrameListener_h_

class UnstableFrameListener : public ExampleFrameListener
{
private:
	SceneManager* mSceneMgr;
public:

    UnstableFrameListener(SceneManager *sceneMgr, RenderWindow* win, Camera* cam)
        : ExampleFrameListener(win, cam),
        mSceneMgr(sceneMgr)
	{
	}

	bool frameStarted(const FrameEvent& evt)
	{
		bool ret = ExampleFrameListener::frameStarted(evt);

	    return ret;
	}

};

#endif // #ifndef __UnstableFrameListener_h_