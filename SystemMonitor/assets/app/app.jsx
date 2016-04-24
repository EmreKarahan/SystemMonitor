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

        var tmp = eval(data);
        console.log(tmp);

        this.setState({ data: tmp });
    }

    renderChartItem(item) {
        return (
    <GoogleDonutChart graphName={"Cpu_" + item.Core} data={item} height="120" key={item.Core} Core={item.Core } />
                      );
    }

    render() {
        return (<div className="row">
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
        this.state = { data: props.data };
    }

    render() {
        var progressStyle = {
            width: this.state.data.Usage + '%'
        };
        return (<div className="col-lg-3 col-sm-4">
                <div><a className="text-success">Core {this.props.Core} Usage: {this.state.data.Usage}%</a></div>
    <div>
                <div className="progress">
    <div className="progress-bar progress-bar-success" role="progressbar" aria-valuenow={this.state.data.Usage} aria-valuemin="0" aria-valuemax="100" style={progressStyle}>
               
    </div>
                </div>
    </div>

        </div>);
    }
    componentWillReceiveProps(nextProps) {
        this.setState({ data: nextProps.data });
    }
    componentDidMount() {

    }
    componentDidUpdate() {


    }

}

ReactDOM.render(
    <App />,
document.getElementById('container')
      );
