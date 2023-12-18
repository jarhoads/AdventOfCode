using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOCLib.Models;
public class CardData
{
    public int Id { get; set; }
    public List<int> Winners { get; set; }
    public List<int> Have { get; set; }

    public CardData(List<int> winners, List<int> have)
    {
        this.Winners = winners;
        this.Have = have;
    }

    public override string ToString()
    {
        return $"Card: {Id} Winners: {String.Join(",", Winners)} Have: {String.Join(",", Have)}";
    }
}
