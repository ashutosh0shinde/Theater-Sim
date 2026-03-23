using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public TicketQueuePos[] ticketQueuepos;

    public Transform ReserveTicketQueue(CustomerAI customerAI)
    {
        foreach(var pos in ticketQueuepos)
        {
            if(!pos.isReserved)
            {
                pos.isReserved = true;
                pos.customerAI = customerAI;
                return pos.pos;
            }
        }
        return null;
    }

    //removes the agent details and unreserves the position of ticket queue
    public void FreeTicketQueue(Transform freepos, CustomerAI customerAI)
    {
        foreach(var pos in ticketQueuepos)
        {
            if(freepos == pos.pos)
            {
                pos.isReserved = false;
                pos.customerAI = null;
            }
        }
    }


    /*
     * LeaveTicketQueue called by agent when leaving the queue
     * frees the queue pos of agent leaving it
     * then repositions the remaining agents
     * 
     * pos -> current pos (posToMove) of leaving agent
     * customerAI -> script of leaving agent
     */
    public void LeaveTicketQueue(Transform pos, CustomerAI customerAI)
    {
        FreeTicketQueue(pos, customerAI);
        customerAI.DestroyAgent();
        for(int i =1;i<ticketQueuepos.Length;i++)
        {
            CustomerAI cs = ticketQueuepos[i].customerAI;
            if (cs == null)
                continue;
            FreeTicketQueue(cs.posToMove, cs);
            cs.ToTicketQueue();
        }
    }
}
