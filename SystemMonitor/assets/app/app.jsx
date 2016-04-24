// ReSharper disable once Es6Feature
class App extends React.Component {
    constructor(props) {
        super(props);
        // this.start = this.start.bind(this);


        var data = [{ "Core": 0, "Usage": 100, "CreateTime": "02:24:21" }, { "Core": 1, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 2, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 3, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 4, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 5, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 6, "Usage": 0, "CreateTime": "02:24:21" }, { "Core": 7, "Usage": 0, "CreateTime": "02:24:21" }];

        this.state = { data: data };

        let hub = $.connection.systemMonitorHub;
        var self = this;
        $.connection.hub.start();
        hub.client.broadCastCpuUsage =
            function (result) {
                self.receiveData(result);
            };
    }

    receiveData(data) {

        this.setState({ data: data });

    }

    renderChartItem(item) {
        return (<GoogleDonutChart graphName={"Cpu_" + item.Core} data={item} height="120" key={item.Core } Core={item.Core} />);
    }

    render() {
        return (<div>
            {(this.state.data).map((result, index) => {
                return this.renderChartItem(result, index);
            })}
        </div>);
    }
}


// ReSharper disable once Es6Feature
class GoogleDonutChart extends React.Component {
    constructor(props) {
        super(props);

        var self = this;
        this.data = [];
        this.data.push(props.data);
        this.state = { data: this.changeData(this.data) };


        this.options = {
            series: {
                shadowSize: 1
            },
            lines: {
                show: true,
                lineWidth: 0.5,
                fill: true,
                fillColor: {
                    colors: [{
                        opacity: 0.1
                    }, {
                        opacity: 1
                    }]
                }
            },
            yaxis: {
                min: 0,
                max: 100,
                tickColor: "#eee",
                tickFormatter: function (v) {
                    return v + "%";
                }
            },
            xaxis: {
                show: false,
            },
            colors: ["#6ef146"],
            grid: {
                tickColor: "#eee",
                borderWidth: 0
            }
        };

        this.plot = null;
        //this.updateInterval = 30;


    }

    render() {
        let divStyle = {
            height: '260px',
            width: '480px'
        }
        return (<div>Core: {this.props.Core}<div className="chart" ref={this.props.graphName} id={this.props.graphName} style={divStyle }></div></div>);
    }
    componentWillReceiveProps(nextProps) {

        this.data.push(nextProps.data);
        this.setState({ data: this.changeData(this.data) });
        
        
        //this.forceUpdate();
        //this.update();
    }
    componentDidMount() {
        this.plot = $.plot($("#" + this.props.graphName), [this.state.data], this.options);
    }
    componentDidUpdate() {
        this.update();
        this.forceUpdate();

    }

    changeData() {
        var tempData = [];
        this.data.forEach(function (d, i) {
            var item = [
                i, d.Usage
            ];
            tempData.push(item);
        });
        return tempData;
    }

    update() {
   
        this.plot.setData([this.state.data]);
        this.plot.draw();
        console.log("Update Core : " + this.props.Core);
        console.log(this.state.data);
    }
}


ReactDOM.render(
    <App />,
document.getElementById('container')
      );
