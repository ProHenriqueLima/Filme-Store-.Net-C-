1 - select s.dsStatus, count(p.idProcesso)
from tb_processo p
left join tb_status s on(s.idStatus = p.idStatus)
group by s.dsStatus;

2 - select p.nroprocesso, max(a.dtandamento)
from tb_andamento a
inner join tb_processo p on(p.idprocesso = a.idprocesso)
where year(p.dtencerramento) = 2013
group by p.nroprocesso;

3 - select p.dtencerramento, count(p.dtencerramento)
from tb_processo p
group by p.dtencerramento
having count(p.dtencerramento) > 5

4 - select tpad(p.nroprocesso, 12, 0) from tb_processo p
