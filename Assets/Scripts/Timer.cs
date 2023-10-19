using UnityEngine;

public delegate void CompleteEvent();
public delegate void UpdateEvent(float t);

public class Timer : MonoBehaviour
{
    UpdateEvent updateEvent;
    CompleteEvent onCompleted;
    bool isLog = true;//�Ƿ��ӡ��Ϣ
    float timeTarget;   // ��ʱʱ��/
    float timeStart;    // ��ʼ��ʱʱ��/
    float offsetTime;   // ��ʱƫ��/
    bool isTimer;       // �Ƿ�ʼ��ʱ/
    bool isDestory = true;     // ��ʱ�������Ƿ�����/
    bool isEnd;         // ��ʱ�Ƿ����/
    bool isIgnoreTimeScale = true;  // �Ƿ����ʱ������
    bool isRepeate;     //�Ƿ��ظ�
    float now;          //��ǰʱ�� ����ʱ
    float downNow;          //����ʱ
    bool isDownNow = false;     //�Ƿ��ǵ���ʱ
    public bool isPaused = false;

    // �Ƿ�ʹ����Ϸ����ʵʱ�� ��������Ϸ��ʱ���ٶ�
    float TimeNow
    {
        get { return isIgnoreTimeScale ? Time.realtimeSinceStartup : Time.time; }
    }

    /// <summary>
    /// ������ʱ��:����  �������ֿ��Դ��������ʱ������
    /// </summary>
    public static Timer createTimer(string gobjName)
    {
        GameObject g = new GameObject(gobjName);
        Timer timer = g.AddComponent<Timer>();
        return timer;
    }

    /// <summary>
    /// ��ʼ��ʱ
    /// </summary>
    /// <param name="time_">Ŀ��ʱ��</param>
    /// <param name="isDownNow">�Ƿ��ǵ���ʱ</param>
    /// <param name="onCompleted_">��ɻص�����</param>
    /// <param name="update">��ʱ�����̻ص�����</param>
    /// <param name="isIgnoreTimeScale_">�Ƿ����ʱ�䱶��</param>
    /// <param name="isRepeate_">�Ƿ��ظ�</param>
    /// <param name="isDestory_">��ɺ��Ƿ�����</param>
    public void startTiming(float timeTarget, bool isDownNow,
        CompleteEvent onCompleted_, UpdateEvent update,
        bool isIgnoreTimeScale, bool isRepeate, bool isDestory,
        float offsetTime = 0, bool isEnd = false, bool isTimer = true)
    {
        this.timeTarget = timeTarget;
        this.isIgnoreTimeScale = isIgnoreTimeScale;
        this.isRepeate = isRepeate;
        this.isDestory = isDestory;
        this.offsetTime = offsetTime;
        this.isEnd = isEnd;
        this.isTimer = isTimer;
        this.isDownNow = isDownNow;
        timeStart = TimeNow;

        if (onCompleted_ != null)
            onCompleted = onCompleted_;
        if (update != null)
            updateEvent = update;
    }

    void Update()
    {
        if (isTimer)
        {
            now = TimeNow - offsetTime - timeStart;
            downNow = timeTarget - now;
            if (updateEvent != null)
            {
                if (isDownNow)
                {
                    updateEvent(downNow);
                }
                else
                {
                    updateEvent(now);
                }
            }
            if (now > timeTarget)
            {
                if (onCompleted != null)
                    onCompleted();
                if (!isRepeate)
                    destory();
                else
                    reStartTimer();
            }
        }
    }

    /// <summary>
    /// ��ȡʣ��ʱ��
    /// </summary>
    /// <returns></returns>
    public float GetTimeNow()
    {
        return Mathf.Clamp(timeTarget - now, 0, timeTarget);
    }

    /// <summary>
    /// ��ʱ����
    /// </summary>
    public void destory()
    {
        isTimer = false;
        isEnd = true;
        if (isDestory)
            Destroy(gameObject);
    }

    float _pauseTime;
    /// <summary>
    /// ��ͣ��ʱ
    /// </summary>
    public void pauseTimer()
    {
        this.isPaused = true;
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("��ʱ�Ѿ�������");
        }
        else
        {
            if (isTimer)
            {
                isTimer = false;
                _pauseTime = TimeNow;
            }
        }
    }

    /// <summary>
    /// ������ʱ
    /// </summary>
    public void connitueTimer()
    {
        this.isPaused = true;
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("��ʱ�Ѿ�����������¼�ʱ��");
        }
        else
        {
            if (!isTimer)
            {
                offsetTime += (TimeNow - _pauseTime);
                isTimer = true;
            }
        }
    }

    /// <summary>
    /// ���¼�ʱ
    /// </summary>
    public void reStartTimer()
    {
        timeStart = TimeNow;
        offsetTime = 0;
    }

    /// <summary>
    /// ����Ŀ��ʱ��
    /// </summary>
    /// <param name="time_"></param>
    public void changeTargetTime(float time_)
    {
        timeTarget = time_;
        timeStart = TimeNow;
    }


    /// <summary>
    /// ��Ϸ��ͣ����
    /// </summary>
    /// <param name="isPause_"></param>
    void OnApplicationPause(bool isPause_)
    {
        if (isPause_)
        {
            pauseTimer();
        }
        else
        {
            connitueTimer();
        }
    }
}
